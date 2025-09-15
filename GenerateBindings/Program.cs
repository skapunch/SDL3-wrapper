using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GenerateBindings;

internal static partial class Program
{
    private enum TypeContext
    {
        StructField,
        FunctionData,
    }

    private class StructDefinitionType
    {
        public bool ContainsUnion { get; set; }
        public List<(uint, string)> OffsetFields { get; } = new();
        public Dictionary<string, RawFFIEntry> InternalStructs { get; } = new();

        public void Reset()
        {
            ContainsUnion = false;
            OffsetFields.Clear();
            InternalStructs.Clear();
        }
    }

    private class FunctionSignatureType
    {
        public enum ReturnIntentType
        {
            None,
            String,
            Array,
        }

        public string Name { get; set; } = "";
        public string ReturnType { get; set; } = "";
        public ReturnIntentType ReturnIntent = ReturnIntentType.None;
        public List<(string, string)> ParameterTypesNames { get; } = new();
        public List<string> HeapAllocatedStringParams { get; } = new();
        public StringBuilder ParameterString { get; } = new();

        public bool RequiresStringMarshalling => (ReturnIntent == ReturnIntentType.String) || (HeapAllocatedStringParams.Count > 0);

        public void Reset()
        {
            Name = "";
            ReturnType = "";
            ReturnIntent = ReturnIntentType.None;
            ParameterTypesNames.Clear();
            HeapAllocatedStringParams.Clear();
            ParameterString.Clear();
        }
    }

  //  private static readonly List<string> DefinedTypes = new();
    private static readonly Dictionary<string, RawFFIEntry> TypedefMap = new();
    private static readonly HashSet<string> UnusedUserProvidedTypes = new();
    private static readonly Dictionary<string, string> ReservedWords = new()
    {
        { "checked", "check" }
    };

    private static readonly StructDefinitionType StructDefinition = new();
    private static readonly FunctionSignatureType FunctionSignature = new();

    //store the types defined and and used in specific context. ie. mixer

    private static bool CoreMode = true;
    private static bool Debug = false;

    private static DirectoryInfo GetSDL3Directory(string[] args)
    {
        return new DirectoryInfo(args[0]);
    }

    //choose whether to export functions for specific module's function
    private static readonly Dictionary<string, bool> ModuleToggle = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

    //{mixer},{mix_somehting1, mix_something2, mix_somehting3}
    private static readonly Dictionary<string, HashSet<string>> ModuleReleventTypes = new();
    private static bool greenLitModules = false;

    //the designated base library
    private static string baseLibrary = "";
    
    private static bool CheckModules(string[] args)
    {
        //starting from args[2] are the modules list
        foreach (var arg in args.Skip(2))
        {
            if (arg == "debug") continue;
            var parts = arg.Split('=', 2, StringSplitOptions.TrimEntries);
            if (parts.Length == 2)
            {
                if (parts[0] != "base")
                {
                    if (bool.TryParse(parts[1], out bool state))
                        ModuleToggle[parts[0]] = state;
                    else
                    {
                        Console.WriteLine($"Error at option: {parts[0]} = {parts[1]}");
                        return false;
                    }
                }
                else if (parts[0] == "base" && baseLibrary == "")
                {
                    if (ModuleToggle.ContainsKey(parts[1]))
                        baseLibrary = parts[1];

                    else
                    {
                        Console.WriteLine($"Unknown base module: {parts[1]} .base should be one of the submitted module");
                        return false;
                    }
                }
                else if (parts[0] == "base" && baseLibrary != "")
                {
                    Console.WriteLine($"More than 1 base module . Please remove base={parts[1]}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Invalid argument: {arg}");
                return false;
            }
        }
        bool result = false;
        foreach (var state in ModuleToggle.Values)
            result |= state;
        if(!result)
            Console.WriteLine("Must enable at least 1 module!");
        return result;
    }

    private static string SetSourceName()
    {
        string name = "SDL3.";
        foreach (var kvp in ModuleToggle)
        {
            var moduleName = kvp.Key.Substring(4);
            if (kvp.Value)
                name += moduleName + ".";
        }
        name += "cs";
        return name;
    }

    private static async Task<int> Main(string[] args)
    {
        // PARSE INPUT
        if (args.Length < 1)
        {
            Console.WriteLine("usage:               GenerateBindings 0<sdl-repo-root-dir> 1<ffi-json> 2[module]");
            Console.WriteLine("sdl-repo-root-dir:   The root directory of SDL3 code.");
            Console.WriteLine(@"module:             SDL_image= , SDL_mixer=true, SDL_ttf=false, SDL_core=false 
                                                    will generate both image and mixer modules of SDL
                                                    (skip the ttf and core)");
            return 1;
        }

        if (!args[1].EndsWith(".json"))
        {
            Console.WriteLine("ffi json not submit");
            return 2;
        } 
        var ffiJsonFile = new FileInfo(Path.Combine(AppContext.BaseDirectory, args[1]));

        if (!CheckModules(args))
        {
            Console.WriteLine("Unable to verify submitted modules.Please check again!");
            return 3;
        }

        Debug = args.Contains("debug");
        var sdlProjectName = "SDL3-skapunch.csproj";

        var sdlDir = GetSDL3Directory(args);

        var sdlBindingsDir = new FileInfo(Path.Combine(AppContext.BaseDirectory, "../../../../SDL3-skapunch/"));
        var sdlBindingsProjectFile = new FileInfo(Path.Combine(sdlBindingsDir.FullName, sdlProjectName));


#if WINDOWS
        var dotnetExe = FindInPath("dotnet.exe");
#else
        var dotnetExe = FindInPath("dotnet");
#endif

        foreach (var key in UserProvidedData.PointerFunctionDataIntents.Keys)
        {
            UnusedUserProvidedTypes.Add(key.Item1);
        }

        foreach (var key in UserProvidedData.ReturnedCharPtrMemoryOwners.Keys)
        {
            UnusedUserProvidedTypes.Add(key);
        }

        foreach (var key in UserProvidedData.ReturnedArrayCountParamNames.Keys)
        {
            UnusedUserProvidedTypes.Add(key);
        }

        foreach (var key in UserProvidedData.DelegateDefinitions.Keys)
        {
            UnusedUserProvidedTypes.Add(key);
        }

        foreach (var key in UserProvidedData.FlagEnumDefinitions.Keys)
        {
            UnusedUserProvidedTypes.Add(key);
        }

        RawFFIEntry[]? ffiData = JsonSerializer.Deserialize<RawFFIEntry[]>(File.ReadAllText(ffiJsonFile.FullName));
        if (ffiData == null)
        {
            Console.WriteLine($"failed to read ffi.json file {ffiJsonFile.FullName}!!");
            return 1;
        }
        greenLitModules = false;
        //construct the module's types
        foreach (var module in ModuleToggle.Keys)
        {
            ModuleReleventTypes[module] = new HashSet<string>();
        }
        foreach (var entry in ffiData)
        {
            
            if (entry.Header == null)
                continue;
            
            if (!IsInLibraryHeader(entry, sdlDir, out var headerFile))
                continue;
            // *** HACKS ***
            if (headerFile.StartsWith("SDL_stdinc.h") && !(entry.Name!.StartsWith("SDL_malloc") || entry.Name!.StartsWith("SDL_free")))
                continue;
            // *** END OF HACKS ***
            var headerName = Path.GetFileNameWithoutExtension(headerFile);
            
                /*            // ** HACKS
                               if (!ModuleToggle.ContainsKey(headerName))
                                   continue;
                               if (!ModuleToggle[headerName])
                                   continue;
                               // ** END OF HACKS */
                //put all the relevent headers to their contextual module
                //Assumming ffi contains all the functions and type of the whole SDL3 and its submodules
                // ** Construct the ModuleReleventTypes's Keys based on the ModuleToggle's Key
                if (ModuleReleventTypes.ContainsKey(headerName))
                {
                    ModuleReleventTypes[headerName].Add(entry.Name!);
                }
                else if (!ModuleReleventTypes.ContainsKey(headerName))
                {
                    //all the SDL_core goes here
                    ModuleReleventTypes[baseLibrary].Add(entry.Name!);
                }
            /*             if (!ModuleReleventTypes.ContainsKey(headerName))
                                    {
                                        //key doesn't exist
                                        ModuleReleventTypes[headerName] = new HashSet<string>();
                                    }
                                    else
                                    {
                                        ModuleReleventTypes[headerName].Add(entry.Name);
                                    } */
        }
        greenLitModules = true;
        //LESSON LEARNED : POPULATE THE TYPEDEF MAP !!AFTER!! THE MODULE CONSTRUCT
        //Populate the typedef map using the ffi json
        foreach (var entry in ffiData)
        {
            //skip all the files that is not start with SDL_
            if ((entry.Header == null) || !IsInLibraryHeader(entry, sdlDir, out _))
            {
                continue;
            }

            if ((entry.Tag == "typedef") && IsInLibraryHeader(entry, sdlDir, out _))
            {
                // Add or update typedef mapping
                TypedefMap[entry.Name!] = entry.Type!;
            }
        }
        //end of populate the typedef map
        if (Debug)
        {
            //await Serialize();
            foreach (var kvp in ModuleReleventTypes)
            {
                Console.WriteLine($"==== Start of {kvp.Key} ========");
                foreach (var value in kvp.Value)
                    Console.WriteLine($"{value}");
                Console.WriteLine($"==== End of {kvp.Key} ========");
                Console.Write("\n");
            }
            Console.WriteLine($"**** Typedef map ********");
            foreach (var key in TypedefMap.Keys)
            {
                Console.WriteLine($"{key}");
            }
            return 4;
        }
        var definitions = new StringBuilder();
        var unknownPointerFunctionData = new StringBuilder();
        var unknownReturnedCharPtrMemoryOwners = new StringBuilder();
        var unknownReturnedArrayCountParamNames = new StringBuilder();
        var undefinedFunctionPointers = new StringBuilder();
        var unpopulatedFlagDefinitions = new StringBuilder();
        var currentSourceFile = "";
        var propsDefinitions = new Dictionary<string, string>();
        var hintsDefinitions = new Dictionary<string, string>();
        var inlinedFunctionNames = new List<string>();

        foreach (var entry in ffiData)
        {
            string headerFile;
            //skip all the files that is not start with SDL_
            if ((entry.Header == null) || !IsInLibraryHeader(entry, sdlDir, out headerFile))
            {
                continue;
            }
            // *** HACKS ***
            if (headerFile.StartsWith("SDL_stdinc.h") && !(entry.Name!.StartsWith("SDL_malloc") || entry.Name!.StartsWith("SDL_free")))
                continue;
            // *** END OF HACKS ***
            string? keyFound = null;
            foreach (var kvp in ModuleReleventTypes)
            {
                var entryName = kvp.Value.FirstOrDefault(v => v == entry.Name);
                if (entryName != null)
                {
                    //found
                    keyFound = kvp.Key; //Get the key at which this sub-value of the value belongs to
                    break;
                }
            }
            if (keyFound != null)
            {
                if (!ModuleToggle[keyFound])
                {
                    //module is red-lit
                    continue; //skip to the next entry
                }
            }
            else
            {
                //not found
                Console.WriteLine($"Inconceivable!! {entry.Name} doesn't belong to any modules");
                return 5;
            }

            if (Path.GetFileName(entry.Header).StartsWith("SDL_stdinc.h") &&
                            !((entry.Name == "SDL_malloc") || (entry.Name == "SDL_free")))
            {
                //in SDL_stdinc.h if it is not SDL_malloc nor SDL_free , skip it!
                //we only need SDL_malloc and SDL_free
                continue;
            }

            if (Path.GetFileName(entry.Header).StartsWith("SDL_system.h"))
            {
                // Ignore SDL_system exports for PC platforms that generate the json
                if (entry.Name == "SDL_WindowsMessageHook" ||
                    entry.Name == "SDL_SetWindowsMessageHook" ||
                    entry.Name == "SDL_GetDirect3D9AdapterIndex" ||
                    entry.Name == "SDL_GetDXGIOutputInfo" ||
                    entry.Name == "SDL_X11EventHook" ||
                    entry.Name == "SDL_SetX11EventHook" ||
                    entry.Name == "SDL_SetLinuxThreadPriority" ||
                    entry.Name == "SDL_SetLinuxThreadPriorityAndPolicy")
                {
                    continue;
                }
            }

            if (UserProvidedData.DeniedTypes.Contains(entry.Name))
            {
                continue;
            }
            var headerPath = entry.Header.Split(":")[0];
            if (currentSourceFile != headerFile)
            {
                definitions.Append($"// {headerPath}\n\n");
                currentSourceFile = headerFile;

                hintsDefinitions.Clear();
                propsDefinitions.Clear();
                inlinedFunctionNames.Clear();

                var isHintsHeader = currentSourceFile.EndsWith("SDL_hints.h");



                IEnumerable<string> fileLines = File.ReadLines(headerPath);
                foreach (var line in fileLines)
                {
                    if (isHintsHeader)
                    {
                        var hintMatch = HintDefinitionRegex().Match(line);
                        if (hintMatch.Success)
                        {
                            hintsDefinitions[hintMatch.Groups["hintName"].Value] = hintMatch.Groups["value"].Value;
                        }
                    }

                    // Extract SDL_PROP_ #define's.  Note that SDL_thread.h currently has some duplicate entries.
                    var propMatch = PropDefinitionRegex().Match(line);
                    if (propMatch.Success)
                    {
                        propsDefinitions[propMatch.Groups["propName"].Value] = propMatch.Groups["value"].Value;
                    }

                    var inlinedFunctionMatch = InlinedFunctionRegex().Match(line);
                    if (inlinedFunctionMatch.Success)
                    {
                        inlinedFunctionNames.Add(inlinedFunctionMatch.Groups["functionName"].Value);
                    }
                }

                if (hintsDefinitions.Count > 0)
                {
                    foreach (KeyValuePair<string, string> definition in hintsDefinitions)
                    {
                        definitions.Append($"public const string {definition.Key} = \"{definition.Value}\";\n");
                    }

                    definitions.Append('\n');
                }

                if (propsDefinitions.Count > 0)
                {
                    foreach (KeyValuePair<string, string> definition in propsDefinitions)
                    {
                        definitions.Append($"public const string {definition.Key} = \"{definition.Value}\";\n");
                    }

                    definitions.Append('\n');
                }
            }

            // IF SAME HEADER 
            if (entry.Tag == "enum")
            {
                definitions.Append($"public enum {entry.Name!}\n{{\n");
                //DefinedTypes.Add(entry.Name!);

                foreach (var enumValue in entry.Fields!)
                {
                    definitions.Append($"{enumValue.Name} = {(int)enumValue.Value!},\n");
                }

                definitions.Append("}\n\n");
            }

            else if (entry.Tag == "typedef")
            {
                if (entry.Type!.Tag == "function-pointer")
                {
                    if (UserProvidedData.DelegateDefinitions.TryGetValue(key: entry.Name!, value: out var delegateDefinition))
                    {
                        UnusedUserProvidedTypes.Remove(entry.Name!);

                        if (delegateDefinition.ReturnType == "WARN_PLACEHOLDER")
                        {
                            definitions.Append("// ");
                        }
                        else
                        {
                            definitions.Append("[UnmanagedFunctionPointer(CallingConvention.Cdecl)]\n");
                            //DefinedTypes.Add(entry.Name!);
                        }

                        definitions.Append($"public delegate {delegateDefinition.ReturnType} {entry.Name}(");

                        var initialParam = true;
                        foreach (var (paramType, paramName) in delegateDefinition.Parameters)
                        {
                            if (initialParam == false)
                            {
                                definitions.Append(", ");
                            }
                            else
                            {
                                initialParam = false;
                            }

                            definitions.Append($"{paramType} {paramName}");
                        }

                        definitions.Append(");\n\n");
                    }
                    else
                    {
                        definitions.Append(
                            $"// public static delegate RETURN {entry.Name}(PARAMS) // WARN_UNDEFINED_FUNCTION_POINTER: {entry.Header}\n\n"
                        );
                        undefinedFunctionPointers.Append(
                            $"{{ \"{entry.Name}\", new DelegateDefinition {{ ReturnType = \"WARN_PLACEHOLDER\", Parameters = [] }} }}, // {entry.Header}\n"
                        );
                    }
                }
                else if (entry.Name == "SDL_Keycode")
                {
                    var enumType = CSharpTypeFromFFI(type: entry.Type!, TypeContext.StructField);
                    definitions.Append($"public enum {entry.Name} : {enumType}\n{{\n");
                    definitions.Append("SDLK_SCANCODE_MASK = 0x40000000,\n");

                    IEnumerable<string> hintsFileLines = File.ReadLines(Path.Combine(sdlDir.FullName, "include/SDL3/SDL_keycode.h"));

                    foreach (var line in hintsFileLines)
                    {
                        var match = KeycodeDefinitionRegex().Match(line);
                        if (match.Success)
                        {
                            definitions.Append($"{match.Groups["keycodeName"].Value} = {match.Groups["value"].Value},\n");
                        }
                    }

                    definitions.Append("}\n\n");
                }
                //my code
                else if (entry.Name == "SDL_BlendMode")
                {
                    var enumType = CSharpTypeFromFFI(type: entry.Type!, TypeContext.StructField);
                    definitions.Append($"public enum {entry.Name} : {enumType}\n{{\n");
                    IEnumerable<string> blendmodeFileLines = File.ReadLines(Path.Combine(sdlDir.FullName, "include/SDL3/SDL_blendmode.h"));
                    foreach (var line in blendmodeFileLines)
                    {
                        var match = BlendmodeDefinitionRegex().Match(line);
                        if (match.Success)
                        {
                            definitions.Append($"{match.Groups["blendmode"].Value} = {match.Groups["value"].Value},\n");
                        }
                    }
                    definitions.Append("}\n\n");
                }

                //end of my code
                else if (entry.Name != null && IsFlagType(entry.Name))
                {
                    definitions.Append("[Flags]\n");
                    var enumType = CSharpTypeFromFFI(type: entry.Type!, TypeContext.StructField);
                    definitions.Append($"public enum {entry.Name} : {enumType}\n{{\n");

                    if (!UserProvidedData.FlagEnumDefinitions.TryGetValue(entry.Name, value: out var enumValues))
                    {
                        unpopulatedFlagDefinitions.Append($"{{ \"{entry.Name}\", [ ] }}, // {entry.Header}\n");
                        definitions.Append("// WARN_UNPOPULATED_FLAG_ENUM\n");
                    }
                    else if (enumValues.Length == 0)
                    {
                        UnusedUserProvidedTypes.Remove(entry.Name!);

                        definitions.Append("// WARN_UNPOPULATED_FLAG_ENUM\n");
                    }
                    else
                    {
                        UnusedUserProvidedTypes.Remove(entry.Name!);

                        for (var i = 0; i < enumValues.Length; i++)
                        {
                            var enumEntry = enumValues[i];
                            if (enumEntry.Contains('='))
                            {
                                definitions.Append($"{enumEntry},\n");
                            }
                            else
                            {
                                definitions.Append($"{enumValues[i]} = 0x{BigInteger.Pow(value: 2, i):X},\n");
                            }
                        }
                    }

                    definitions.Append("}\n\n");
                }
            }

            else if ((entry.Tag == "struct") || (entry.Tag == "union"))
            {
                TypedefMap[entry.Name!] = entry;
                if (entry.Fields!.Length == 0)
                {
                    continue;
                }

                //DefinedTypes.Add(entry.Name!);
                ConstructStruct(structName: entry.Name!, entry, definitions);

                while (StructDefinition.InternalStructs.Count > 0)
                {
                    var internalStructs = new Dictionary<string, RawFFIEntry>(StructDefinition.InternalStructs);
                    foreach (var (internalStructName, internalStructEntry) in internalStructs)
                    {
                        ConstructStruct(internalStructName, internalStructEntry, definitions);
                    }
                }
            }

            else if (entry.Tag == "function")
            {
                if (inlinedFunctionNames.Contains(entry.Name!))
                {
                    continue;
                }

                var hasVarArgs = false;
                foreach (var parameter in entry.Parameters!)
                {
                    if (parameter.Type!.Tag == "va_list")
                    {
                        hasVarArgs = true;
                        break;
                    }
                }

                if (hasVarArgs)
                {
                    continue;
                }

                FunctionSignature.Reset();

                FunctionSignature.Name = entry.Name!;

                var functionComponents = new RawFFIEntry[entry.Parameters!.Length + 1];
                functionComponents[0] = entry.ReturnType!;
                Array.Copy(entry.Parameters!, 0, functionComponents, 1, entry.Parameters!.Length);

                var containsUnknownRef = false;

                foreach (var component in functionComponents)
                {
                    var isReturn = component == entry.ReturnType!;
                    var componentName = isReturn ? "__return" : component.Name!;
                    var componentType = isReturn ? component : component.Type!;
                    string typeName;

                    if ((componentType.Tag == "pointer") && IsDefinedType(componentType.Type!))
                    {
                        var subtype = GetTypeFromTypedefMap(type: componentType.Type!);
                        var subtypeName = CSharpTypeFromFFI(subtype, TypeContext.FunctionData);

                        if (subtypeName == "UTF8_STRING") // pointer to an array; give up
                        {
                            typeName = "IntPtr";
                        }
                        else if (subtypeName == "char")
                        {
                            typeName = "UTF8_STRING";
                            if (isReturn)
                            {
                                FunctionSignature.ReturnIntent = FunctionSignatureType.ReturnIntentType.String;
                            }
                            else
                            {
                                FunctionSignature.HeapAllocatedStringParams.Add(SanitizeName(componentName));
                            }
                        }
                        else if (UserProvidedData.PointerFunctionDataIntents.TryGetValue(key: (FunctionSignature.Name, componentName), value: out var intent))
                        {
                            if (subtypeName == "FUNCTION_POINTER")
                            {
                                subtypeName = componentType.Type!.Tag;
                            }

                            UnusedUserProvidedTypes.Remove(entry.Name!);

                            if (
                                isReturn &&
                                intent
                                    is UserProvidedData.PointerFunctionDataIntent.Ref
                                    or UserProvidedData.PointerFunctionDataIntent.In
                                    or UserProvidedData.PointerFunctionDataIntent.Out
                                    or UserProvidedData.PointerFunctionDataIntent.OutArray
                            )
                            {
                                Console.WriteLine($"{FunctionSignature.Name}: intent `{intent}` unsupported for return types; falling back to IntPtr");
                                typeName = "IntPtr";
                            }
                            else
                            {
                                switch (intent)
                                {
                                    case UserProvidedData.PointerFunctionDataIntent.IntPtr:
                                        typeName = "IntPtr";
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.Ref:
                                        typeName = $"ref {subtypeName}";
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.In:
                                        typeName = $"in {subtypeName}";
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.Out:
                                        typeName = $"out {subtypeName}";
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.Array:
                                        if (isReturn)
                                        {
                                            typeName = "IntPtr";
                                        }
                                        else
                                        {
                                            typeName = $"Span<{subtypeName}>";
                                        }
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.OutArray:
                                        typeName = $"Span<{subtypeName}>";
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.Pointer:
                                        typeName = $"{subtypeName}*";
                                        break;
                                    case UserProvidedData.PointerFunctionDataIntent.Unknown:
                                    default:
                                        typeName = "IntPtr";
                                        containsUnknownRef = true;
                                        break;
                                }
                            }

                            if (CoreMode && isReturn && (intent == UserProvidedData.PointerFunctionDataIntent.Array))
                            {
                                FunctionSignature.ReturnIntent = FunctionSignatureType.ReturnIntentType.Array;
                            }
                        }
                        else
                        {
                            typeName = isReturn ? $"{subtypeName}*" : $"ref {subtypeName}";
                            containsUnknownRef = true;
                            unknownPointerFunctionData.Append(
                                $"{{ (\"{entry.Name!}\", \"{componentName}\"), PointerFunctionDataIntent.Unknown }}, // {entry.Header}\n"
                            );
                        }
                    }
                    else
                    {
                        var foundTypedef = GetTypeFromTypedefMap(componentType);
                        typeName = CSharpTypeFromFFI(foundTypedef, TypeContext.FunctionData);
                        if (typeName == "FUNCTION_POINTER")
                        {
                            if (componentType.Tag == "SDL_FunctionPointer")
                            {
                                typeName = "IntPtr";
                            }
                            else
                            {
                                typeName = $"{componentType.Tag}";
                            }
                        }
                    }

                    if (isReturn)
                    {
                        //is the return type of the function signature
                        FunctionSignature.ReturnType = typeName;
                        if (FunctionSignature.ReturnType == "FUNCTION_POINTER")
                        {
                            FunctionSignature.ReturnType = "IntPtr";
                        }
                    }
                    else
                    {
                        //add to parameters list of the function signature
                        FunctionSignature.ParameterTypesNames.Add((typeName, SanitizeName(componentName)));
                    }
                }

                foreach (var (type, name) in FunctionSignature.ParameterTypesNames)
                {
                    if (FunctionSignature.ParameterString.Length > 0)
                    {
                        FunctionSignature.ParameterString.Append(", ");
                    }

                    var outputName = name;
                    if (ReservedWords.TryGetValue(name, out var replacementName))
                    {
                        outputName = replacementName;
                    }

                    FunctionSignature.ParameterString.Append($"{type} {outputName}");
                }



                // Handle array -> span marshalling by generating a helper function
                if (FunctionSignature.ReturnIntent == FunctionSignatureType.ReturnIntentType.Array)
                {
                    if (UserProvidedData.ReturnedArrayCountParamNames.TryGetValue(FunctionSignature.Name, value: out var countParamName))
                    {
                        UnusedUserProvidedTypes.Remove(FunctionSignature.Name);

                        var stringList = new List<string>();
                        foreach (var (typeName, name) in FunctionSignature.ParameterTypesNames)
                        {
                            if (countParamName != name)
                            {
                                stringList.Add($"{typeName} {name}");
                            }
                        }
                        var signatureArgs = $"({string.Join(", ", stringList)})";

                        stringList.Clear();
                        foreach (var (typeName, name) in FunctionSignature.ParameterTypesNames)
                        {
                            if (countParamName != name)
                            {
                                stringList.Add($"{name}");
                            }
                            else
                            {
                                stringList.Add($"out var {name}");
                            }
                        }
                        var arguments = $"({string.Join(", ", stringList)})";

                        stringList.Clear();
                        foreach (var (typeName, name) in FunctionSignature.ParameterTypesNames)
                        {
                            if (countParamName != name)
                            {
                                stringList.Add($"{name}");
                            }
                        }
                        var argumentsWithoutCount = string.Join(", ", stringList);

                        var componentType = entry.ReturnType!;
                        var subtype = GetTypeFromTypedefMap(type: componentType.Type!);
                        var subtypeName = CSharpTypeFromFFI(subtype, TypeContext.FunctionData);

                        definitions.Append($"public static Span<{subtypeName}> {FunctionSignature.Name}{signatureArgs}\n");
                        definitions.Append("{\n");
                        definitions.Append($"var result = {FunctionSignature.Name}{arguments};\n");
                        definitions.Append($"return new Span<{subtypeName}>((void*) result, {countParamName});\n");
                        definitions.Append("}\n\n");
                    }
                    else
                    {
                        unknownReturnedArrayCountParamNames.Append(
                            $"{{ \"{FunctionSignature.Name!}\", \"WARN_MISSING_COUNT_PARAM_NAME\" }}, // {entry.Header}\n"
                        );
                    }
                }

                // ** HACKS 
                var prefix = entry.Name!.Substring(0, 4).ToUpperInvariant();
                string nativeLibName;

                if (prefix == "IMG_")
                    nativeLibName = "\"SDL3_image\"";
                else if (prefix == "TTF_")
                    nativeLibName = "\"SDL3_ttf\"";
                else if (prefix == "MIX_")
                    nativeLibName = "\"SDL3_mixer\"";
                else
                    nativeLibName = "\"SDL3\"";
                // ** END OF HACKS
                if (FunctionSignature.RequiresStringMarshalling)
                {
                    definitions.Append("[LibraryImport(" + nativeLibName + ", StringMarshalling = StringMarshalling.Utf8)]");
                }
                else
                {
                    definitions.Append("[LibraryImport(" + nativeLibName + ")]\n");
                }

                definitions.Append($"[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]\n");

                // Handle string marshalling
                if (FunctionSignature.ReturnIntent == FunctionSignatureType.ReturnIntentType.String)
                {
                    if (UserProvidedData.ReturnedCharPtrMemoryOwners.TryGetValue(FunctionSignature.Name, value: out var memoryOwner))
                    {
                        UnusedUserProvidedTypes.Remove(FunctionSignature.Name);
                        if (memoryOwner == UserProvidedData.ReturnedCharPtrMemoryOwner.Caller)
                        {
                            definitions.Append("[return: MarshalUsing(typeof(CallerOwnedStringMarshaller))]\n");
                        }
                        else
                        {
                            definitions.Append("[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]\n");
                        }
                    }
                    else
                    {
                        unknownReturnedCharPtrMemoryOwners.Append(
                            $"{{ \"{FunctionSignature.Name!}\", ReturnedCharPtrMemoryOwner.Unknown }}, // {entry.Header}\n"
                        );
                    }
                }

                definitions.Append($"public static partial {FunctionSignature.ReturnType.Replace("UTF8_STRING", "string")} {entry.Name}(");


                definitions.Append(FunctionSignature.ParameterString.ToString().Replace("UTF8_STRING", "string"));

                definitions.Append("); ");
                if (containsUnknownRef)
                {
                    definitions.Append("// WARN_UNKNOWN_POINTER_PARAMETER");
                }

                definitions.Append("\n\n");
            }
        }

        var outputFilename = SetSourceName();

        File.WriteAllText(
            path: Path.Combine(sdlBindingsDir.FullName, outputFilename),
            contents: CompileBindingsCSharp(definitions.ToString())
        );

        RunProcess(dotnetExe, args: $"format {sdlBindingsProjectFile}");

        //hard-code text file 
        if (unknownPointerFunctionData.Length > 0)
        {
            WriteUnused("unknowPointerFunctionsData.txt",$"new pointer parameters (add these to `PointerFunctionDataIntents` in UserProvidedData.cs:\n{unknownPointerFunctionData}\n");
        }

        if (unknownReturnedCharPtrMemoryOwners.Length > 0)
        {
            WriteUnused("unknowReturnedCharPtrMemoryOwners.txt",
                $"new returned char pointers (add these to `ReturnedCharPtrMemoryOwners` in UserProvidedData.cs:\n{unknownReturnedCharPtrMemoryOwners}\n"
            );
        }

        if (unknownReturnedArrayCountParamNames.Length > 0)
        {
            WriteUnused("unknowReturnedArrayCountParamNames.txt",
                $"new returned arrays (add these to `ReturnedArrayCountParamNames` in UserProvidedData.cs and specify the name of the param that contains the element count:\n{unknownReturnedArrayCountParamNames}\n"
            );
        }

        if (undefinedFunctionPointers.Length > 0)
        {
            WriteUnused("undefinedFunctionPointers.txt",
                $"new undefined function pointers (add these to `DelegateDefinitions` in UserProvidedData.cs:\n{undefinedFunctionPointers}\n"
            );
        }

        if (unpopulatedFlagDefinitions.Length > 0)
        {
            WriteUnused("unpopulatedFlagDefinitions.txt",$"new unpopulated flag enums (add these to `FlagEnumDefinitions` in UserProvidedData.cs:\n{unpopulatedFlagDefinitions}\n");
        }

        return 0;
    }

    //I have made an assumption that before entering this function
    //  we've already rule out that anything that is Std-related 
    //  had been filter out.Namely anything that isn't in a header file
    //  that started with 'SDL_'
    private static bool IsTypeRelevent(RawFFIEntry entry)
    {
        bool result = false;
        if (greenLitModules)
        {
            foreach (var moduleTypes in ModuleReleventTypes.Values)
            {
                result = moduleTypes.Contains(entry.Tag!);
                if (result)
                    break;
            }
            return result;
        }
        else
        {
            Console.WriteLine("Modules didn't get green-lit!!");
            return false;
        }
    }

    private static bool IsInLibraryHeader(RawFFIEntry entry, DirectoryInfo dir, out string headerFile)
    {
        headerFile = Path.GetFileName(entry.Header!.Split(":")[0]);
        var rootFolder = Path.GetFullPath(dir.FullName);
        return Directory
            .EnumerateFiles(rootFolder, headerFile, SearchOption.AllDirectories)
            .Any();
    }
    private static void WriteUnused(string fileName, string? content)
    {
        using (StreamWriter writer = File.CreateText(fileName))
        {
            writer.Write(content!);
        }
    }
    private static FileInfo FindInPath(string exeName)
    {
        var envPath = Environment.GetEnvironmentVariable("PATH");
        if (envPath != null)
        {
            foreach (var envPathDir in envPath.Split(Path.PathSeparator))
            {
                var path = Path.Combine(envPathDir, exeName);
                if (File.Exists(path))
                {
                    return new FileInfo(path);
                }
            }
        }

        return new FileInfo("");
    }

    private static Process RunProcess(FileInfo exe, string args, bool redirectStdOut = false, DirectoryInfo? workingDir = null)
    {
        var process = new Process();
        process.StartInfo.FileName = exe.FullName;
        process.StartInfo.Arguments = args;
        process.StartInfo.RedirectStandardOutput = redirectStdOut;
        process.StartInfo.WorkingDirectory = workingDir?.FullName ?? AppContext.BaseDirectory;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;

        process.Start();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            throw new SystemException($@"process `{exe.FullName} {args}` failed!!\n");
        }

        return process;
    }

    private static string CompileBindingsCSharp(string definitions)
    {
        string output;

        output = @"// NOTE: This file is auto-generated.
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.CompilerServices;
using System.Text;

namespace SDL3;

public static unsafe partial class SDL
{";
        if (ModuleToggle[baseLibrary])
        {
            output += @"
// Custom marshaller for SDL-owned strings returned by SDL.
[CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(SDLOwnedStringMarshaller))]
public static unsafe class SDLOwnedStringMarshaller
{
    /// <summary>
    /// Converts an unmanaged string to a managed version.
    /// </summary>
    /// <returns>A managed string.</returns>
    public static string ConvertToManaged(byte* unmanaged)
        => Marshal.PtrToStringUTF8((IntPtr)unmanaged);
}

// Custom marshaller for caller-owned strings returned by SDL.
[CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(CallerOwnedStringMarshaller))]
public static unsafe class CallerOwnedStringMarshaller
{
    /// <summary>
    /// Converts an unmanaged string to a managed version.
    /// </summary>
    /// <returns>A managed string.</returns>
    public static string ConvertToManaged(byte* unmanaged)
        => Marshal.PtrToStringUTF8((IntPtr)unmanaged);

    /// <summary>
    /// Free the memory for a specified unmanaged string.
    /// </summary>
    public static void Free(byte* unmanaged)
        => SDL_free((IntPtr)unmanaged);
}

// Taken from https://github.com/ppy/SDL3-CS
// C# bools are not blittable, so we need this workaround
public readonly record struct SDLBool
{
    private readonly byte value;

    internal const byte FALSE_VALUE = 0;
    internal const byte TRUE_VALUE = 1;

    internal SDLBool(byte value)
    {
        this.value = value;
    }

    public static implicit operator bool(SDLBool b)
    {
        return b.value != FALSE_VALUE;
    }

    public static implicit operator SDLBool(bool b)
    {
        return new SDLBool(b ? TRUE_VALUE : FALSE_VALUE);
    }

    public bool Equals(SDLBool other)
    {
        return other.value == value;
    }

    public override int GetHashCode()
    {
        return value.GetHashCode();
    }
}
";
        }
    
        output += $@"

    {definitions}
}}
";
        return output;
    }

    public class TupleKeyDictionaryConverter<TValue>
        : JsonConverter<Dictionary<(string, string), TValue>>
    {
        public override Dictionary<(string, string), TValue> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var dict = new Dictionary<(string, string), TValue>();

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            reader.Read();

            while (reader.TokenType == JsonTokenType.PropertyName)
            {
                var keyString = reader.GetString()!;
                var parts = keyString.Split(':', 2);
                var key = (parts[0], parts.Length > 1 ? parts[1] : "");

                reader.Read();
                var value = JsonSerializer.Deserialize<TValue>(ref reader, options)!;

                dict[key] = value;

                reader.Read();
            }

            return dict;
        }

        public override void Write(
            Utf8JsonWriter writer,
            Dictionary<(string, string), TValue> value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var kvp in value)
            {
                writer.WritePropertyName($"{kvp.Key.Item1}:{kvp.Key.Item2}");
                JsonSerializer.Serialize(writer, kvp.Value, options);
            }

            writer.WriteEndObject();
        }
    }
    private static async Task Serialize()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // Register both converters
        options.Converters.Add(new JsonStringEnumConverter());
        options.Converters.Add(new TupleKeyDictionaryConverter<UserProvidedData.PointerFunctionDataIntent>());

        await using var stream = File.Create("PointerFunctionDataIntents.json");
        await JsonSerializer.SerializeAsync(stream, UserProvidedData.PointerFunctionDataIntents, options);

    }
    private static RawFFIEntry GetTypeFromTypedefMap(RawFFIEntry type)
    {
        if (IsTypeRelevent(type))
        {
            // preserve flag types
            if (IsFlagType(type.Tag))
            {
                return type;
            }

            if (TypedefMap.TryGetValue(type.Tag, value: out var value))
            {
                return value;
            }
        }

        return type;
    }

    private static string CSharpTypeFromFFI(RawFFIEntry type, TypeContext context)
    {
        if ((type.Tag == "pointer") && IsDefinedType(type.Type!))
        {
            var subtype = GetTypeFromTypedefMap(type.Type!);
            var subtypeName = CSharpTypeFromFFI(subtype, context);

            if (subtypeName == "char")
            {
                return context == TypeContext.StructField ? "byte*" : "UTF8_STRING";
            }

            return context switch
            {
                TypeContext.StructField => $"{subtypeName}*",
                _                       => "IntPtr",
            };
        }
        
        //end of my code
            return type.Tag switch
        {
            "_Bool" => "SDLBool",
            "Sint8" => "sbyte",
            "Sint16" => "short",
            "int" => "int",
            "Sint32" => "int",
            "long" => "long",
            "Sint64" => "long",
            "Uint8" => "byte",
            "unsigned-short" => "ushort",
            "Uint16" => "ushort",
            "unsigned-int" => "uint",
            "Uint32" => "uint",
            "unsigned-long" => "ulong",
            "Uint64" => "ulong",
            "float" => "float",
            "double" => "double",
            "size_t" => "UIntPtr",
            "wchar_t" => "char",
            "unsigned-char" => "byte",
            "void" => "void",
            "pointer" => "IntPtr",
            "function-pointer" => "FUNCTION_POINTER",
            "enum" => type.Name!,
            "struct" => type.Name!,
            "array" => "INLINE_ARRAY",
            "union" => type.Name!,
            _ => type.Tag,
        };
    }

    private static string SanitizeName(string unsanitizedName)
    {
        return unsanitizedName switch
        {
            "internal" => "@internal",
            "event"    => "@event",
            "override" => "@override",
            "base"     => "@base",
            "lock"     => "@lock",
            "string"   => "@string",
            ""         => "_",
            _          => unsanitizedName,
        };
    }

    private static bool IsDefinedType(RawFFIEntry type)
    {
        if (type.Tag == null) return false;

        return
            (type.Name != "void") || TypedefMap.ContainsKey(type.Tag);
    }

    private static void ConstructStruct(string structName, RawFFIEntry entry, StringBuilder definitions)
    {
        StructDefinition.Reset();
        ConstructStructFields(entry, typePrefix: $"{structName}_");

        if (StructDefinition.ContainsUnion)
        {
            definitions.Append("[StructLayout(LayoutKind.Explicit)]\n");
            definitions.Append($"public struct {structName}\n{{\n");

            foreach (var (offset, field) in StructDefinition.OffsetFields)
            {
                definitions.Append($"[FieldOffset({offset})]\n");
                definitions.Append($"{field}\n");
            }

            definitions.Append("}\n\n");
        }
        else
        {
            definitions.Append("[StructLayout(LayoutKind.Sequential)]\n");
            definitions.Append($"public struct {structName}\n{{\n");

            foreach (var (offset, field) in StructDefinition.OffsetFields)
            {
                definitions.Append($"{field}\n");
            }

            definitions.Append("}\n\n");
        }
    }

    private static void ConstructStructFields(
        RawFFIEntry entry,
        uint byteOffset = 0,
        string typePrefix = "",
        string namePrefix = ""
    )
    {
        if (entry.Tag == "union")
        {
            StructDefinition.ContainsUnion = true;
        }

        foreach (var field in entry.Fields!)
        {
            var fieldName = SanitizeName($"{namePrefix}{field.Name!}");
            var fieldTypedef = GetTypeFromTypedefMap(type: field.Type!);
            var fieldTypeName = CSharpTypeFromFFI(fieldTypedef, TypeContext.StructField);
            if ((fieldTypeName == "") && (fieldTypedef.Tag == "union"))
            {
                ConstructStructFields(
                    fieldTypedef,
                    byteOffset: byteOffset + (uint) field.BitOffset! / 8,
                    typePrefix,
                    namePrefix: $"{fieldName}_"
                );
            }
            else if ((fieldTypeName == "") && (fieldTypedef.Tag == "struct"))
            {
                var internalStructName = $"INTERNAL_{typePrefix}{fieldName}";
                StructDefinition.InternalStructs.Add(internalStructName, fieldTypedef);
                StructDefinition.OffsetFields.Add(
                    (
                        byteOffset + (uint) field.BitOffset! / 8,
                        $"public {internalStructName} {fieldName};"
                    )
                );
            }
            //fields such ass padding[i] etc.
            else if (fieldTypeName == "INLINE_ARRAY")
            {
                var elementTypeName = CSharpTypeFromFFI(type: fieldTypedef.Type!, TypeContext.StructField);
                if (elementTypeName.StartsWith("SDL_")) // fixed buffers only work on primitives
                {
                    var elementByteSize = GetTypeFromTypedefMap(fieldTypedef.Type!).BitSize ?? 0 / 8;
                    for (var i = 0; i < fieldTypedef.Size; i++)
                    {
                        StructDefinition.OffsetFields.Add(
                            (
                                byteOffset + (uint)(elementByteSize * i) + (uint)field.BitOffset! / 8,
                                $"public {elementTypeName} {fieldName}{i};"
                            )
                        );
                    }
                }
                else
                {
                    StructDefinition.OffsetFields.Add(
                        (
                            byteOffset + (uint)field.BitOffset! / 8,
                            $"public fixed {elementTypeName} {fieldName}[{fieldTypedef.Size}];"
                        )
                    );
                }
            }
            else if (fieldTypeName == "FUNCTION_POINTER")
            {
                string context;
                if (field.Type!.Tag == "function-pointer")
                {
                    context = "WARN_ANONYMOUS_FUNCTION_POINTER";
                }
                else
                {
                    context = $"{field.Type!.Tag}";
                }

                StructDefinition.OffsetFields.Add(
                    (
                        byteOffset + (uint)field.BitOffset! / 8,
                        $"public IntPtr {fieldName}; // {context}"
                    )
                );
            }
            else
            {
                StructDefinition.OffsetFields.Add(
                    (
                        byteOffset + (uint)field.BitOffset! / 8,
                        $"public {fieldTypeName} {fieldName};"
                    )
                );
            }
        }
    }

    private static bool IsFlagType(string name)
    {
        return name.EndsWith("Flags") || UserProvidedData.FlagTypes.Contains(name);
    }


    private static void PopulateDefinitions()
    {}

    [GeneratedRegex(@"#define\s+(?<hintName>SDL_HINT_[A-Z0-9_]+)\s+""(?<value>.+)""")]
    private static partial Regex HintDefinitionRegex();

    [GeneratedRegex(@"#define\s+(?<keycodeName>SDLK_[A-Z0-9_]+)\s+(?<value>0x[0-9a-f]+u)")]
    private static partial Regex KeycodeDefinitionRegex();

    [GeneratedRegex(@"#define\s+(?<blendmode>SDL_BLENDMODE_[A-Z0-9_]+)\s+(?<value>0x[0-9a-f]+u)", RegexOptions.IgnoreCase)]
    private static partial Regex BlendmodeDefinitionRegex();

    [GeneratedRegex(@"#define\s+(?<propName>SDL_PROP_[A-Z0-9_]+)\s+""(?<value>[^""]*)""")]
    private static partial Regex PropDefinitionRegex();

    [GeneratedRegex(@"(SDL_FORCE_INLINE|SDLMAIN_DECLSPEC).*\s+(?<functionName>[a-zA-Z0-9_]+)\(.*\)")]
    private static partial Regex InlinedFunctionRegex();
}
