namespace GenerateBindings;

internal static class UserProvidedData
{
    internal enum PointerFunctionDataIntent
    {
        Unknown,
        IntPtr,
        Ref,
        Out,
        Array,
        OutArray,
        Pointer,
        In,
    }

    internal enum ReturnedCharPtrMemoryOwner
    {
        Unknown,
        SDL,
        Caller,
    }

    internal struct DelegateDefinition
    {
        public string ReturnType { get; set; }
        public (string, string)[] Parameters { get; set; }
    }

    internal static readonly Dictionary<(string, string), PointerFunctionDataIntent> PointerFunctionDataIntents = new()
    {
        { ("SDL_AcquireCameraFrame", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_camera.h:433:43
        { ("SDL_AcquireCameraFrame", "timestampNS"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_camera.h:431:43
        { ("SDL_AcquireGPUSwapchainTexture", "swapchain_texture"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gpu.h:3380:34
        { ("SDL_AcquireGPUSwapchainTexture", "swapchain_texture_height"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gpu.h:3380:34
        { ("SDL_AcquireGPUSwapchainTexture", "swapchain_texture_width"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gpu.h:3380:34
        { ("SDL_AddAtomicInt", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:406:33
        { ("SDL_AddSurfaceAlternateImage", "image"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:333:34
        { ("SDL_AddSurfaceAlternateImage", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:333:34
        { ("SDL_AttachVirtualJoystick", "desc"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_joystick.h:482:44
        { ("SDL_BeginGPUComputePass", "storage_buffer_bindings"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2866:49
        { ("SDL_BeginGPUComputePass", "storage_texture_bindings"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2866:49
        { ("SDL_BeginGPURenderPass", "color_target_infos"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2493:48
        { ("SDL_BeginGPURenderPass", "depth_stencil_target_info"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2493:48
        { ("SDL_BindAudioStreams", "streams"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:838:34
        { ("SDL_BindGPUComputeSamplers", "texture_sampler_bindings"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2899:34
        { ("SDL_BindGPUComputeStorageBuffers", "storage_buffers"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2937:34
        { ("SDL_BindGPUComputeStorageTextures", "storage_textures"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2918:34
        { ("SDL_BindGPUFragmentSamplers", "texture_sampler_bindings"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2670:34
        { ("SDL_BindGPUFragmentStorageBuffers", "storage_buffers"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2708:34
        { ("SDL_BindGPUFragmentStorageTextures", "storage_textures"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2689:34
        { ("SDL_BindGPUIndexBuffer", "binding"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2593:34
        { ("SDL_BindGPUVertexBuffers", "bindings"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2576:34
        { ("SDL_BindGPUVertexSamplers", "texture_sampler_bindings"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2612:34
        { ("SDL_BindGPUVertexStorageBuffers", "storage_buffers"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2650:34
        { ("SDL_BindGPUVertexStorageTextures", "storage_textures"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:2631:34
        { ("SDL_BlitGPUTexture", "info"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3218:34
        { ("SDL_BlitSurface", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1077:34
        { ("SDL_BlitSurface", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1077:34
        { ("SDL_BlitSurface", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1077:34
        { ("SDL_BlitSurface", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1077:34
        { ("SDL_BlitSurface9Grid", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1246:34
        { ("SDL_BlitSurface9Grid", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1246:34
        { ("SDL_BlitSurface9Grid", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1246:34
        { ("SDL_BlitSurface9Grid", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1246:34
        { ("SDL_BlitSurfaceScaled", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1127:34
        { ("SDL_BlitSurfaceScaled", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1127:34
        { ("SDL_BlitSurfaceScaled", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1127:34
        { ("SDL_BlitSurfaceScaled", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1127:34
        { ("SDL_BlitSurfaceTiled", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1179:34
        { ("SDL_BlitSurfaceTiled", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1179:34
        { ("SDL_BlitSurfaceTiled", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1179:34
        { ("SDL_BlitSurfaceTiled", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1179:34
        { ("SDL_BlitSurfaceTiledWithScale", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1209:34
        { ("SDL_BlitSurfaceTiledWithScale", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1209:34
        { ("SDL_BlitSurfaceTiledWithScale", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1209:34
        { ("SDL_BlitSurfaceTiledWithScale", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1209:34
        { ("SDL_BlitSurfaceUnchecked", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1102:34
        { ("SDL_BlitSurfaceUnchecked", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1102:34
        { ("SDL_BlitSurfaceUnchecked", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1102:34
        { ("SDL_BlitSurfaceUnchecked", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1102:34
        { ("SDL_BlitSurfaceUncheckedScaled", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1153:34
        { ("SDL_BlitSurfaceUncheckedScaled", "dstrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1153:34
        { ("SDL_BlitSurfaceUncheckedScaled", "src"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1153:34
        { ("SDL_BlitSurfaceUncheckedScaled", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1153:34
        { ("SDL_ClearSurface", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:952:34
        { ("SDL_CompareAndSwapAtomicInt", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:348:34
        { ("SDL_CompareAndSwapAtomicPointer", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:548:34
        { ("SDL_CompareAndSwapAtomicU32", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:490:34
        { ("SDL_ConvertAudioSamples", "dst_data"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_audio.h:1981:34
        { ("SDL_ConvertAudioSamples", "dst_len"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1981:34
        { ("SDL_ConvertAudioSamples", "dst_spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:1981:34
        { ("SDL_ConvertAudioSamples", "src_data"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_audio.h:1981:34
        { ("SDL_ConvertAudioSamples", "src_spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:1981:34
        { ("SDL_ConvertEventToRenderCoordinates", "event"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1485:34
        { ("SDL_ConvertSurface", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:835:43
        { ("SDL_ConvertSurface", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:819:43
        { ("SDL_ConvertSurfaceAndColorspace", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:862:43
        { ("SDL_ConvertSurfaceAndColorspace", "palette"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:846:43
        { ("SDL_ConvertSurfaceAndColorspace", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:846:43
        { ("SDL_CopyGPUBufferToBuffer", "destination"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3142:34
        { ("SDL_CopyGPUBufferToBuffer", "source"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3142:34
        { ("SDL_CopyGPUTextureToTexture", "destination"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3116:34
        { ("SDL_CopyGPUTextureToTexture", "source"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3116:34
        { ("SDL_CreateAudioStream", "dst_spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:937:47
        { ("SDL_CreateAudioStream", "src_spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:937:47
        { ("SDL_CreateColorCursor", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_mouse.h:460:42
        { ("SDL_CreateCursor", "data"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_mouse.h:429:42
        { ("SDL_CreateCursor", "mask"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_mouse.h:429:42
        { ("SDL_CreateGPUBuffer", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2122:44
        { ("SDL_CreateGPUComputePipeline", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:1946:53
        { ("SDL_CreateGPUGraphicsPipeline", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:1965:54
        { ("SDL_CreateGPUSampler", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:1984:45
        { ("SDL_CreateGPUShader", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2053:44
        { ("SDL_CreateGPUTexture", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2088:45
        { ("SDL_CreateGPUTransferBuffer", "createinfo"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2144:52
        { ("SDL_CreateHapticEffect", "effect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_haptic.h:1184:33
        { ("SDL_CreatePalette", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_pixels.h:846:43
        { ("SDL_CreateSoftwareRenderer", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:312:44
        { ("SDL_CreateSurface", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:156:43
        { ("SDL_CreateSurfaceFrom", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:184:43
        { ("SDL_CreateSurfacePalette", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:294:43
        { ("SDL_CreateSurfacePalette", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:278:43
        { ("SDL_CreateTexture", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:544:43
        { ("SDL_CreateTextureFromSurface", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:572:43
        { ("SDL_CreateTextureFromSurface", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:555:43
        { ("SDL_CreateTextureWithProperties", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:685:43
        { ("SDL_CreateWindowAndRenderer", "renderer"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:194:34
        { ("SDL_CreateWindowAndRenderer", "window"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:194:34
        { ("SDL_DateTimeToTime", "dt"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_time.h:146:34
        { ("SDL_DestroyPalette", "palette"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_pixels.h:877:34
        { ("SDL_DestroySurface", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:183:34
        { ("SDL_DestroyTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2299:34
        { ("SDL_DownloadFromGPUBuffer", "destination"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3179:34
        { ("SDL_DownloadFromGPUBuffer", "source"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3179:34
        { ("SDL_DownloadFromGPUTexture", "destination"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3162:34
        { ("SDL_DownloadFromGPUTexture", "source"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3162:34
        { ("SDL_DuplicateSurface", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:790:43
        { ("SDL_DuplicateSurface", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:774:43
        { ("SDL_FillSurfaceRect", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:977:34
        { ("SDL_FillSurfaceRect", "rect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:977:34
        { ("SDL_FillSurfaceRects", "dst"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1002:34
        { ("SDL_FillSurfaceRects", "rects"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_surface.h:1002:34
        { ("SDL_FlipSurface", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:756:34
        { ("SDL_GL_GetAttribute", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:2648:34
        { ("SDL_GL_GetSwapInterval", "interval"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:2813:34
        { ("SDL_GetAssertionHandler", "puserdata"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_assert.h:489:50
        { ("SDL_GetAssertionReport", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_assert.h:542:52
        { ("SDL_GetAtomicInt", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:385:33
        { ("SDL_GetAtomicPointer", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:585:36
        { ("SDL_GetAtomicU32", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:527:36
        { ("SDL_GetAudioDeviceChannelMap", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:565:35
        { ("SDL_GetAudioDeviceChannelMap", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:565:35
        { ("SDL_GetAudioDeviceFormat", "sample_frames"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:542:34
        { ("SDL_GetAudioDeviceFormat", "spec"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:542:34
        { ("SDL_GetAudioPlaybackDevices", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:461:49
        { ("SDL_GetAudioRecordingDevices", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:490:49
        { ("SDL_GetAudioStreamFormat", "dst_spec"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:966:34
        { ("SDL_GetAudioStreamFormat", "src_spec"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:966:34
        { ("SDL_GetAudioStreamInputChannelMap", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:1136:35
        { ("SDL_GetAudioStreamInputChannelMap", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1111:35
        { ("SDL_GetAudioStreamOutputChannelMap", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:1160:35
        { ("SDL_GetAudioStreamOutputChannelMap", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1135:35
        { ("SDL_GetCameraFormat", "spec"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_camera.h:388:34
        { ("SDL_GetCameraSupportedFormats", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_camera.h:222:47
        { ("SDL_GetCameraSupportedFormats", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_camera.h:222:47
        { ("SDL_GetCameras", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_camera.h:183:44
        { ("SDL_GetClipboardData", "size"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_clipboard.h:227:36
        { ("SDL_GetClipboardMimeTypes", "num_mime_types"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_clipboard.h:256:37
        { ("SDL_GetClosestFullscreenDisplayMode", "mode"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:609:34
        { ("SDL_GetCurrentDisplayMode", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:716:53
        { ("SDL_GetCurrentRenderOutputSize", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:501:34
        { ("SDL_GetCurrentRenderOutputSize", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:501:34
        { ("SDL_GetDateTimeLocalePreferences", "dateFormat"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_time.h:103:34
        { ("SDL_GetDateTimeLocalePreferences", "timeFormat"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_time.h:103:34
        { ("SDL_GetDesktopDisplayMode", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:697:53
        { ("SDL_GetDisplayBounds", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:486:34
        { ("SDL_GetDisplayForPoint", "point"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_video.h:661:43
        { ("SDL_GetDisplayForRect", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_video.h:676:43
        { ("SDL_GetDisplayUsableBounds", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:510:34
        { ("SDL_GetDisplays", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:415:45
        { ("SDL_GetEventFilter", "filter"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_events.h:1348:34
        { ("SDL_GetEventFilter", "userdata"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_events.h:1348:34
        { ("SDL_GetFullscreenDisplayModes", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_video.h:649:48
        { ("SDL_GetFullscreenDisplayModes", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:580:48
        { ("SDL_GetGamepadBindings", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gamepad.h:1031:51
        { ("SDL_GetGamepadBindings", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:1011:51
        { ("SDL_GetGamepadMappings", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:403:37
        { ("SDL_GetGamepadPowerInfo", "percent"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:936:44
        { ("SDL_GetGamepadSensorData", "data"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_gamepad.h:1340:34
        { ("SDL_GetGamepadTouchpadFinger", "down"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:1268:34
        { ("SDL_GetGamepadTouchpadFinger", "pressure"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:1268:34
        { ("SDL_GetGamepadTouchpadFinger", "x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:1268:34
        { ("SDL_GetGamepadTouchpadFinger", "y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:1268:34
        { ("SDL_GetGamepads", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gamepad.h:482:46
        { ("SDL_GetGlobalMouseState", "x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:243:50
        { ("SDL_GetGlobalMouseState", "y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:243:50
        { ("SDL_GetHaptics", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_haptic.h:943:44
        { ("SDL_GetJoystickAxisInitialState", "state"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:1013:34
        { ("SDL_GetJoystickBall", "dx"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:1034:34
        { ("SDL_GetJoystickBall", "dy"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:1034:34
        { ("SDL_GetJoystickGUIDInfo", "crc16"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:837:34
        { ("SDL_GetJoystickGUIDInfo", "product"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:837:34
        { ("SDL_GetJoystickGUIDInfo", "vendor"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:837:34
        { ("SDL_GetJoystickGUIDInfo", "version"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:837:34
        { ("SDL_GetJoystickPowerInfo", "percent"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:1200:44
        { ("SDL_GetJoysticks", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_joystick.h:215:46
        { ("SDL_GetKeyboardState", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_keyboard.h:144:42
        { ("SDL_GetKeyboardState", "numkeys"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_keyboard.h:144:42
        { ("SDL_GetKeyboards", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_keyboard.h:89:46
        { ("SDL_GetLogOutputFunction", "callback"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_log.h:490:34
        { ("SDL_GetLogOutputFunction", "userdata"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_log.h:490:34
        { ("SDL_GetMasksForPixelFormat", "Amask"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:787:34
        { ("SDL_GetMasksForPixelFormat", "Bmask"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:787:34
        { ("SDL_GetMasksForPixelFormat", "Gmask"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:787:34
        { ("SDL_GetMasksForPixelFormat", "Rmask"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:787:34
        { ("SDL_GetMasksForPixelFormat", "bpp"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:787:34
        { ("SDL_GetMice", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:167:43
        { ("SDL_GetMouseState", "x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:213:50
        { ("SDL_GetMouseState", "y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:213:50
        { ("SDL_GetPathInfo", "info"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_filesystem.h:413:34
        { ("SDL_GetPixelFormatDetails", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_pixels.h:826:60
        { ("SDL_GetPowerInfo", "percent"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_power.h:85:44
        { ("SDL_GetPowerInfo", "seconds"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_power.h:85:44
        { ("SDL_GetPreferredLocales", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_locale.h:101:43
        { ("SDL_GetPreferredLocales", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_locale.h:101:43
        { ("SDL_GetRGB", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:982:34
        { ("SDL_GetRGB", "format"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:982:34
        { ("SDL_GetRGB", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:982:34
        { ("SDL_GetRGB", "palette"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:982:34
        { ("SDL_GetRGB", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:982:34
        { ("SDL_GetRGBA", "a"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:1014:34
        { ("SDL_GetRGBA", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:1014:34
        { ("SDL_GetRGBA", "format"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:1014:34
        { ("SDL_GetRGBA", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:1014:34
        { ("SDL_GetRGBA", "palette"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:1014:34
        { ("SDL_GetRGBA", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_pixels.h:1014:34
        { ("SDL_GetRectAndLineIntersection", "X1"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:294:34
        { ("SDL_GetRectAndLineIntersection", "X2"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:294:34
        { ("SDL_GetRectAndLineIntersection", "Y1"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:294:34
        { ("SDL_GetRectAndLineIntersection", "Y2"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:294:34
        { ("SDL_GetRectAndLineIntersection", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:294:34
        { ("SDL_GetRectAndLineIntersectionFloat", "X1"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:499:34
        { ("SDL_GetRectAndLineIntersectionFloat", "X2"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:499:34
        { ("SDL_GetRectAndLineIntersectionFloat", "Y1"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:499:34
        { ("SDL_GetRectAndLineIntersectionFloat", "Y2"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:499:34
        { ("SDL_GetRectAndLineIntersectionFloat", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:499:34
        { ("SDL_GetRectEnclosingPoints", "clip"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:274:34
        { ("SDL_GetRectEnclosingPoints", "points"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_rect.h:274:34
        { ("SDL_GetRectEnclosingPoints", "result"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_rect.h:274:34
        { ("SDL_GetRectEnclosingPointsFloat", "clip"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:478:34
        { ("SDL_GetRectEnclosingPointsFloat", "points"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_rect.h:478:34
        { ("SDL_GetRectEnclosingPointsFloat", "result"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_rect.h:478:34
        { ("SDL_GetRectIntersection", "A"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:241:34
        { ("SDL_GetRectIntersection", "B"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:241:34
        { ("SDL_GetRectIntersection", "result"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_rect.h:241:34
        { ("SDL_GetRectIntersectionFloat", "A"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:444:34
        { ("SDL_GetRectIntersectionFloat", "B"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:444:34
        { ("SDL_GetRectIntersectionFloat", "result"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_rect.h:444:34
        { ("SDL_GetRectUnion", "A"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:255:34
        { ("SDL_GetRectUnion", "B"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:255:34
        { ("SDL_GetRectUnion", "result"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_rect.h:255:34
        { ("SDL_GetRectUnionFloat", "A"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:458:34
        { ("SDL_GetRectUnionFloat", "B"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:458:34
        { ("SDL_GetRectUnionFloat", "result"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_rect.h:458:34
        { ("SDL_GetRelativeMouseState", "x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:262:50
        { ("SDL_GetRelativeMouseState", "y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_mouse.h:262:50
        { ("SDL_GetRenderClipRect", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1604:34
        { ("SDL_GetRenderColorScale", "scale"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1800:34
        { ("SDL_GetRenderDrawColor", "a"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1736:34
        { ("SDL_GetRenderDrawColor", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1736:34
        { ("SDL_GetRenderDrawColor", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1736:34
        { ("SDL_GetRenderDrawColor", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1736:34
        { ("SDL_GetRenderDrawColorFloat", "a"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1760:34
        { ("SDL_GetRenderDrawColorFloat", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1760:34
        { ("SDL_GetRenderDrawColorFloat", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1760:34
        { ("SDL_GetRenderDrawColorFloat", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1760:34
        { ("SDL_GetRenderLogicalPresentation", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1400:34
        { ("SDL_GetRenderLogicalPresentation", "mode"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1400:34
        { ("SDL_GetRenderLogicalPresentation", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1400:34
        { ("SDL_GetRenderLogicalPresentationRect", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1422:34
        { ("SDL_GetRenderOutputSize", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:479:34
        { ("SDL_GetRenderOutputSize", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:479:34
        { ("SDL_GetRenderSafeArea", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1568:34
        { ("SDL_GetRenderScale", "scaleX"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1662:34
        { ("SDL_GetRenderScale", "scaleY"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1662:34
        { ("SDL_GetRenderTarget", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1355:43
        { ("SDL_GetRenderVSync", "vsync"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:2426:34
        { ("SDL_GetRenderViewport", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1526:34
        { ("SDL_GetRendererFromTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:848:44
        { ("SDL_GetSensorData", "data"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_sensor.h:280:34
        { ("SDL_GetSensors", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_sensor.h:151:44
        { ("SDL_GetStorageFileSize", "length"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_storage.h:263:34
        { ("SDL_GetStoragePathInfo", "info"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_storage.h:398:34
        { ("SDL_GetSurfaceAlphaMod", "alpha"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:672:34
        { ("SDL_GetSurfaceAlphaMod", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:672:34
        { ("SDL_GetSurfaceBlendMode", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:704:34
        { ("SDL_GetSurfaceClipRect", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:744:34
        { ("SDL_GetSurfaceClipRect", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:744:34
        { ("SDL_GetSurfaceColorKey", "key"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:596:34
        { ("SDL_GetSurfaceColorKey", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:596:34
        { ("SDL_GetSurfaceColorMod", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:637:34
        { ("SDL_GetSurfaceColorMod", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:637:34
        { ("SDL_GetSurfaceColorMod", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:637:34
        { ("SDL_GetSurfaceColorMod", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:637:34
        { ("SDL_GetSurfaceColorspace", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:250:44
        { ("SDL_GetSurfaceImages", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_surface.h:388:44
        { ("SDL_GetSurfaceImages", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:372:44
        { ("SDL_GetSurfaceImages", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:372:44
        { ("SDL_GetSurfacePalette", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:324:43
        { ("SDL_GetSurfacePalette", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:308:43
        { ("SDL_GetSurfaceProperties", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:211:46
        { ("SDL_GetTextInputArea", "cursor"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_keyboard.h:518:34
        { ("SDL_GetTextInputArea", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_keyboard.h:518:34
        { ("SDL_GetTextureAlphaMod", "alpha"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1018:34
        { ("SDL_GetTextureAlphaMod", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1035:34
        { ("SDL_GetTextureAlphaModFloat", "alpha"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1036:34
        { ("SDL_GetTextureAlphaModFloat", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1053:34
        { ("SDL_GetTextureBlendMode", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1088:34
        { ("SDL_GetTextureColorMod", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:928:34
        { ("SDL_GetTextureColorMod", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:928:34
        { ("SDL_GetTextureColorMod", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:928:34
        { ("SDL_GetTextureColorMod", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:945:34
        { ("SDL_GetTextureColorModFloat", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:948:34
        { ("SDL_GetTextureColorModFloat", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:948:34
        { ("SDL_GetTextureColorModFloat", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:948:34
        { ("SDL_GetTextureColorModFloat", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:965:34
        { ("SDL_GetTextureProperties", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:808:46
        { ("SDL_GetTextureScaleMode", "scaleMode"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1107:34
        { ("SDL_GetTextureScaleMode", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1124:34
        { ("SDL_GetTextureSize", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:848:34
        { ("SDL_GetTextureSize", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:865:34
        { ("SDL_GetTextureSize", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:848:34
        { ("SDL_GetTouchDevices", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_touch.h:93:43
        { ("SDL_GetTouchFingers", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_touch.h:129:43
        { ("SDL_GetTouchFingers", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_touch.h:129:43
        { ("SDL_GetWindowAspectRatio", "max_aspect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1562:34
        { ("SDL_GetWindowAspectRatio", "min_aspect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1562:34
        { ("SDL_GetWindowBordersSize", "bottom"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1597:34
        { ("SDL_GetWindowBordersSize", "left"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1597:34
        { ("SDL_GetWindowBordersSize", "right"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1597:34
        { ("SDL_GetWindowBordersSize", "top"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1597:34
        { ("SDL_GetWindowFromEvent", "event"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_events.h:1465:42
        { ("SDL_GetWindowFullscreenMode", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:846:53
        { ("SDL_GetWindowICCProfile", "size"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:790:36
        { ("SDL_GetWindowMaximumSize", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1683:34
        { ("SDL_GetWindowMaximumSize", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1683:34
        { ("SDL_GetWindowMinimumSize", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1649:34
        { ("SDL_GetWindowMinimumSize", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1649:34
        { ("SDL_GetWindowMouseRect", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:2264:46
        { ("SDL_GetWindowPosition", "x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1429:34
        { ("SDL_GetWindowPosition", "y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1429:34
        { ("SDL_GetWindowSafeArea", "rect"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1506:34
        { ("SDL_GetWindowSize", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1486:34
        { ("SDL_GetWindowSize", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1486:34
        { ("SDL_GetWindowSizeInPixels", "h"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1615:34
        { ("SDL_GetWindowSizeInPixels", "w"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:1615:34
        { ("SDL_GetWindowSurface", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:2046:43
        { ("SDL_GetWindowSurfaceVSync", "vsync"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:2006:34
        { ("SDL_GetWindows", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_video.h:885:43
        { ("SDL_GetWindows", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:816:43
        { ("SDL_GlobDirectory", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_filesystem.h:446:37
        { ("SDL_GlobStorageDirectory", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_storage.h:448:37
        { ("SDL_HapticEffectSupported", "effect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_haptic.h:1167:34
        { ("SDL_HasRectIntersection", "A"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:224:34
        { ("SDL_HasRectIntersection", "B"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:224:34
        { ("SDL_HasRectIntersectionFloat", "A"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:427:34
        { ("SDL_HasRectIntersectionFloat", "B"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_rect.h:427:34
        { ("SDL_LoadBMP", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:476:43
        { ("SDL_LoadBMP_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:458:43
        { ("SDL_LoadFile", "datasize"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:671:36
        { ("SDL_LoadFile_IO", "datasize"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:651:36
        { ("SDL_LoadWAV", "audio_buf"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1915:34
        { ("SDL_LoadWAV", "audio_len"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1915:34
        { ("SDL_LoadWAV", "spec"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1915:34
        { ("SDL_LoadWAV_IO", "audio_buf"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1879:34
        { ("SDL_LoadWAV_IO", "audio_len"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1879:34
        { ("SDL_LoadWAV_IO", "spec"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_audio.h:1879:34
        { ("SDL_LockSurface", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:411:34
        { ("SDL_LockTexture", "pitch"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1240:34
        { ("SDL_LockTexture", "pixels"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1240:34
        { ("SDL_LockTexture", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1240:34
        { ("SDL_LockTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1257:34
        { ("SDL_LockTextureToSurface", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1278:34
        { ("SDL_LockTextureToSurface", "surface"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1278:34
        { ("SDL_LockTextureToSurface", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1295:34
        { ("SDL_MapRGB", "format"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:915:36
        { ("SDL_MapRGB", "palette"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:915:36
        { ("SDL_MapRGBA", "format"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:954:36
        { ("SDL_MapRGBA", "palette"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:954:36
        { ("SDL_MapSurfaceRGB", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1276:36
        { ("SDL_MapSurfaceRGBA", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:1307:36
        { ("SDL_MixAudio", "dst"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_audio.h:1951:34
        { ("SDL_MixAudio", "src"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_audio.h:1951:34
        { ("SDL_OpenAudioDevice", "spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:641:47
        { ("SDL_OpenAudioDeviceStream", "spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:1707:47
        { ("SDL_OpenCamera", "spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_camera.h:302:42
        { ("SDL_OpenIO", "iface"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_iostream.h:402:44
        { ("SDL_OpenStorage", "iface"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_storage.h:215:43
        { ("SDL_PeepEvents", "events"), PointerFunctionDataIntent.OutArray }, // /usr/local/include/SDL3/SDL_events.h:1047:33
        { ("SDL_PollEvent", "event"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_events.h:1178:34
        { ("SDL_PremultiplySurfaceAlpha", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:932:34
        { ("SDL_PushEvent", "event"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_events.h:1262:34
        { ("SDL_ReadProcess", "datasize"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_process.h:283:36
        { ("SDL_ReadProcess", "exitcode"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_process.h:283:36
        { ("SDL_ReadS16BE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:766:34
        { ("SDL_ReadS16LE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:734:34
        { ("SDL_ReadS32BE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:830:34
        { ("SDL_ReadS32LE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:798:34
        { ("SDL_ReadS64BE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:894:34
        { ("SDL_ReadS64LE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:862:34
        { ("SDL_ReadS8", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:702:34
        { ("SDL_ReadSurfacePixel", "a"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1334:34
        { ("SDL_ReadSurfacePixel", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1334:34
        { ("SDL_ReadSurfacePixel", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1334:34
        { ("SDL_ReadSurfacePixel", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1334:34
        { ("SDL_ReadSurfacePixel", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:1334:34
        { ("SDL_ReadSurfacePixelFloat", "a"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1358:34
        { ("SDL_ReadSurfacePixelFloat", "b"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1358:34
        { ("SDL_ReadSurfacePixelFloat", "g"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1358:34
        { ("SDL_ReadSurfacePixelFloat", "r"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_surface.h:1358:34
        { ("SDL_ReadSurfacePixelFloat", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:1358:34
        { ("SDL_ReadU16BE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:750:34
        { ("SDL_ReadU16LE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:718:34
        { ("SDL_ReadU32BE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:814:34
        { ("SDL_ReadU32LE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:782:34
        { ("SDL_ReadU64BE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:878:34
        { ("SDL_ReadU64LE", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:846:34
        { ("SDL_ReadU8", "value"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_iostream.h:690:34
        { ("SDL_ReleaseCameraFrame", "frame"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_camera.h:459:34
        { ("SDL_RemoveSurfaceAlternateImages", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:388:34
        { ("SDL_RenderCoordinatesFromWindow", "x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1442:34
        { ("SDL_RenderCoordinatesFromWindow", "y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1442:34
        { ("SDL_RenderCoordinatesToWindow", "window_x"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1464:34
        { ("SDL_RenderCoordinatesToWindow", "window_y"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_render.h:1464:34
        { ("SDL_RenderFillRect", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1978:34
        { ("SDL_RenderFillRects", "rects"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_render.h:1996:34
        { ("SDL_RenderGeometry", "indices"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_render.h:2134:34
        { ("SDL_RenderGeometry", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2173:34
        { ("SDL_RenderGeometry", "vertices"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_render.h:2134:34
        { ("SDL_RenderGeometryRaw", "color"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:2166:34
        { ("SDL_RenderGeometryRaw", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2205:34
        { ("SDL_RenderGeometryRaw", "uv"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:2166:34
        { ("SDL_RenderGeometryRaw", "xy"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:2166:34
        { ("SDL_RenderLines", "points"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_render.h:1925:34
        { ("SDL_RenderPoints", "points"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_render.h:1888:34
        { ("SDL_RenderReadPixels", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2232:43
        { ("SDL_RenderReadPixels", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2193:43
        { ("SDL_RenderRect", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1942:34
        { ("SDL_RenderRects", "rects"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_render.h:1960:34
        { ("SDL_RenderTexture", "dstrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2018:34
        { ("SDL_RenderTexture", "srcrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2018:34
        { ("SDL_RenderTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2057:34
        { ("SDL_RenderTexture9Grid", "dstrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2110:34
        { ("SDL_RenderTexture9Grid", "srcrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2110:34
        { ("SDL_RenderTexture9Grid", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2149:34
        { ("SDL_RenderTextureRotated", "center"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2046:34
        { ("SDL_RenderTextureRotated", "dstrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2046:34
        { ("SDL_RenderTextureRotated", "srcrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2046:34
        { ("SDL_RenderTextureRotated", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2085:34
        { ("SDL_RenderTextureTiled", "dstrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2076:34
        { ("SDL_RenderTextureTiled", "srcrect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:2076:34
        { ("SDL_RenderTextureTiled", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:2115:34
        { ("SDL_ReportAssertion", "data"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_assert.h:245:45
        { ("SDL_SaveBMP", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:504:34
        { ("SDL_SaveBMP_IO", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:483:34
        { ("SDL_ScaleSurface", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:809:43
        { ("SDL_ScaleSurface", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:793:43
        { ("SDL_SendJoystickVirtualSensorData", "data"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_joystick.h:635:34
        { ("SDL_SetAtomicInt", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:368:33
        { ("SDL_SetAtomicPointer", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:567:36
        { ("SDL_SetAtomicU32", "a"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_atomic.h:510:36
        { ("SDL_SetAudioStreamFormat", "dst_spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:997:34
        { ("SDL_SetAudioStreamFormat", "src_spec"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_audio.h:997:34
        { ("SDL_SetAudioStreamInputChannelMap", "chmap"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:1186:34
        { ("SDL_SetAudioStreamOutputChannelMap", "chmap"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:1233:34
        { ("SDL_SetGPUScissor", "scissor"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2533:34
        { ("SDL_SetGPUViewport", "viewport"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:2521:34
        { ("SDL_SetInitialized", "state"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_mutex.h:904:34
        { ("SDL_SetPaletteColors", "colors"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_pixels.h:863:34
        { ("SDL_SetPaletteColors", "palette"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_pixels.h:863:34
        { ("SDL_SetRenderClipRect", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1586:34
        { ("SDL_SetRenderTarget", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1338:34
        { ("SDL_SetRenderViewport", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1509:34
        { ("SDL_SetSurfaceAlphaMod", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:657:34
        { ("SDL_SetSurfaceBlendMode", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:690:34
        { ("SDL_SetSurfaceClipRect", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_surface.h:725:34
        { ("SDL_SetSurfaceClipRect", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:725:34
        { ("SDL_SetSurfaceColorKey", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:561:34
        { ("SDL_SetSurfaceColorMod", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:619:34
        { ("SDL_SetSurfaceColorspace", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:233:34
        { ("SDL_SetSurfacePalette", "palette"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:295:34
        { ("SDL_SetSurfacePalette", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:295:34
        { ("SDL_SetSurfaceRLE", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:523:34
        { ("SDL_SetTextInputArea", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_keyboard.h:499:34
        { ("SDL_SetTextureAlphaMod", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:991:34
        { ("SDL_SetTextureAlphaModFloat", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1017:34
        { ("SDL_SetTextureBlendMode", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1072:34
        { ("SDL_SetTextureColorMod", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:894:34
        { ("SDL_SetTextureColorModFloat", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:924:34
        { ("SDL_SetTextureScaleMode", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1108:34
        { ("SDL_SetWindowFullscreenMode", "mode"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_video.h:763:34
        { ("SDL_SetWindowIcon", "icon"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:1366:34
        { ("SDL_SetWindowMouseRect", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_video.h:2169:34
        { ("SDL_SetWindowShape", "shape"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_video.h:2396:34
        { ("SDL_ShouldInit", "state"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_mutex.h:864:34
        { ("SDL_ShouldQuit", "state"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_mutex.h:885:34
        { ("SDL_ShowMessageBox", "buttonid"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_messagebox.h:164:34
        { ("SDL_ShowMessageBox", "messageboxdata"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_messagebox.h:164:34
        { ("SDL_ShowOpenFileDialog", "filters"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_dialog.h:154:34
        { ("SDL_ShowSaveFileDialog", "filters"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_dialog.h:209:34
        { ("SDL_SurfaceHasAlternateImages", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:347:34
        { ("SDL_SurfaceHasColorKey", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:576:34
        { ("SDL_SurfaceHasRLE", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:537:34
        { ("SDL_TimeToDateTime", "dt"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_time.h:131:34
        { ("SDL_TimeToWindows", "dwHighDateTime"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_time.h:162:34
        { ("SDL_TimeToWindows", "dwLowDateTime"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_time.h:162:34
        { ("SDL_UnbindAudioStreams", "streams"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_audio.h:879:34
        { ("SDL_UnlockSurface", "surface"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_surface.h:422:34
        { ("SDL_UnlockTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1316:34
        { ("SDL_UpdateHapticEffect", "data"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_haptic.h:1206:34
        { ("SDL_UpdateNVTexture", "UVplane"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:1205:34
        { ("SDL_UpdateNVTexture", "Yplane"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:1205:34
        { ("SDL_UpdateNVTexture", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1205:34
        { ("SDL_UpdateNVTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1222:34
        { ("SDL_UpdateTexture", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1141:34
        { ("SDL_UpdateTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1158:34
        { ("SDL_UpdateWindowSurfaceRects", "rects"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_video.h:2052:34
        { ("SDL_UpdateYUVTexture", "Uplane"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:1173:34
        { ("SDL_UpdateYUVTexture", "Vplane"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:1173:34
        { ("SDL_UpdateYUVTexture", "Yplane"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:1173:34
        { ("SDL_UpdateYUVTexture", "rect"), PointerFunctionDataIntent.Ref }, // /usr/local/include/SDL3/SDL_render.h:1173:34
        { ("SDL_UpdateYUVTexture", "texture"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_render.h:1190:34
        { ("SDL_UploadToGPUBuffer", "destination"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3093:34
        { ("SDL_UploadToGPUBuffer", "source"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3093:34
        { ("SDL_UploadToGPUTexture", "destination"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3071:34
        { ("SDL_UploadToGPUTexture", "source"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_gpu.h:3071:34
        { ("SDL_WaitEvent", "event"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_events.h:1200:34
        { ("SDL_WaitEventTimeout", "event"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_events.h:1228:34
        { ("SDL_WaitForGPUFences", "fences"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_gpu.h:3466:34
        { ("SDL_WaitProcess", "exitcode"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_process.h:383:34
        { ("SDL_WaitThread", "status"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_thread.h:423:34
        { ("SDL_WriteSurfacePixel", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:1381:34
        { ("SDL_WriteSurfacePixelFloat", "surface"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_surface.h:1401:34
        { ("SDL_hid_enumerate", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_hidapi.h:240:51
        { ("SDL_hid_free_enumeration", "devs"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_hidapi.h:252:34
        { ("SDL_hid_get_device_info", "__return"), PointerFunctionDataIntent.Pointer }, // /usr/local/include/SDL3/SDL_hidapi.h:519:51

        //Set the first byte of data to the Report ID of the report to be read. 
        // Make sure to allow space for this extra byte in data. 
        // Upon return, the first byte will still contain the Report ID, and the report data will start in data[1].
        { ("SDL_hid_get_feature_report", "data"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:420:33
        { ("SDL_hid_get_input_report", "data"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:443:33
        { ("SDL_hid_get_report_descriptor", "buf"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:535:33
        { ("SDL_hid_read", "data"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:353:33
        { ("SDL_hid_read_timeout", "data"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:332:33
        { ("SDL_hid_send_feature_report", "data"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:397:33
        { ("SDL_hid_write", "data"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_hidapi.h:311:33
        { ("SDL_GetAsyncIOResult", "outcome"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_asyncio.h:438:34
        { ("SDL_WaitAsyncIOResult", "outcome"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_asyncio.h:482:34
        { ("SDL_GetClosestFullscreenDisplayMode", "closest"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_video.h:800:34
        { ("SDL_WaitAndAcquireGPUSwapchainTexture", "swapchain_texture"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gpu.h:3800:34
        { ("SDL_WaitAndAcquireGPUSwapchainTexture", "swapchain_texture_width"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gpu.h:3800:34
        { ("SDL_WaitAndAcquireGPUSwapchainTexture", "swapchain_texture_height"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_gpu.h:3800:34
        { ("SDL_RenderTextureAffine", "texture"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_render.h:2117:34
        { ("SDL_RenderTextureAffine", "srcrect"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_render.h:2117:34
        { ("SDL_RenderTextureAffine", "origin"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_render.h:2117:34
        { ("SDL_RenderTextureAffine", "right"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_render.h:2117:34
        { ("SDL_RenderTextureAffine", "down"), PointerFunctionDataIntent.In }, // /usr/local/include/SDL3/SDL_render.h:2117:34
        { ("SDL_CreateTray", "icon"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_tray.h:115:39
        { ("SDL_SetTrayIcon", "icon"), PointerFunctionDataIntent.IntPtr }, // /usr/local/include/SDL3/SDL_tray.h:127:34
        { ("SDL_GetTrayEntries", "__return"), PointerFunctionDataIntent.Array }, // /usr/local/include/SDL3/SDL_tray.h:240:51
        { ("SDL_GetTrayEntries", "count"), PointerFunctionDataIntent.Out }, // /usr/local/include/SDL3/SDL_tray.h:240:51

        { ("IMG_GetAnimationDecoderFrame", "frame"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2704:34
        { ("IMG_GetAnimationDecoderFrame", "duration"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2704:34
        { ("SDL_StretchSurface", "src"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3/SDL_surface.h:1298:34
        { ("SDL_StretchSurface", "srcrect"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3/SDL_surface.h:1298:34
        { ("SDL_StretchSurface", "dst"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3/SDL_surface.h:1298:34
        { ("SDL_StretchSurface", "dstrect"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3/SDL_surface.h:1298:34
        { ("IMG_LoadTyped_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:133:43
        { ("IMG_Load", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:178:43
        { ("IMG_Load_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:232:43
        { ("IMG_LoadTexture", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:267:43
        { ("IMG_LoadTexture_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:314:43
        { ("IMG_LoadTextureTyped_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:369:43
        { ("IMG_LoadAVIF_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1178:43
        { ("IMG_LoadICO_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1212:43
        { ("IMG_LoadCUR_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1246:43
        { ("IMG_LoadBMP_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1280:43
        { ("IMG_LoadGIF_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1314:43
        { ("IMG_LoadJPG_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1348:43
        { ("IMG_LoadJXL_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1382:43
        { ("IMG_LoadLBM_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1416:43
        { ("IMG_LoadPCX_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1450:43
        { ("IMG_LoadPNG_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1484:43
        { ("IMG_LoadPNM_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1518:43
        { ("IMG_LoadSVG_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1552:43
        { ("IMG_LoadQOI_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1586:43
        { ("IMG_LoadTGA_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1620:43
        { ("IMG_LoadTIF_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1654:43
        { ("IMG_LoadXCF_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1688:43
        { ("IMG_LoadXPM_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1722:43
        { ("IMG_LoadXV_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1756:43
        { ("IMG_LoadWEBP_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1790:43
        { ("IMG_LoadSizedSVG_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1811:43
        { ("IMG_ReadXPMFromArray", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1830:43
        { ("IMG_ReadXPMFromArrayToRGB888", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1849:43
        { ("IMG_Save", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1874:34
        { ("IMG_SaveTyped_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1906:34
        { ("IMG_SaveAVIF", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1924:34
        { ("IMG_SaveAVIF_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1947:34
        { ("IMG_SaveBMP", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1969:34
        { ("IMG_SaveBMP_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:1996:34
        { ("IMG_SaveGIF", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2012:34
        { ("IMG_SaveGIF_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2033:34
        { ("IMG_SaveJPG", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2051:34
        { ("IMG_SaveJPG_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2074:34
        { ("IMG_SavePNG", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2090:34
        { ("IMG_SavePNG_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2111:34
        { ("IMG_SaveTGA", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2127:34
        { ("IMG_SaveTGA_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2148:34
        { ("IMG_SaveWEBP", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2168:34
        { ("IMG_SaveWEBP_IO", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2193:34
        { ("IMG_LoadAnimation", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2226:45
        { ("IMG_LoadAnimation_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2253:45
        { ("IMG_LoadAnimationTyped_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2287:45
        { ("IMG_FreeAnimation", "anim"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2306:34
        { ("IMG_LoadAPNGAnimation_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2332:44
        { ("IMG_LoadAVIFAnimation_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2358:44
        { ("IMG_LoadGIFAnimation_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2381:45
        { ("IMG_LoadWEBPAnimation_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2404:45
        { ("IMG_AddAnimationEncoderFrame", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_image/SDL_image.h:2522:34
        { ("TTF_GetFreeTypeVersion", "major"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:91:34
        { ("TTF_GetFreeTypeVersion", "minor"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:91:34
        { ("TTF_GetFreeTypeVersion", "patch"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:91:34
        { ("TTF_GetHarfBuzzVersion", "major"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:106:34
        { ("TTF_GetHarfBuzzVersion", "minor"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:106:34
        { ("TTF_GetHarfBuzzVersion", "patch"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:106:34
        { ("TTF_GetFontDPI", "hdpi"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:439:34
        { ("TTF_GetFontDPI", "vdpi"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:439:34
        { ("TTF_GetGlyphImage", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1162:43
        { ("TTF_GetGlyphImage", "image_type"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1162:43
        { ("TTF_GetGlyphImageForIndex", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1182:43
        { ("TTF_GetGlyphImageForIndex", "image_type"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1182:43
        { ("TTF_GetGlyphMetrics", "minx"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1213:34
        { ("TTF_GetGlyphMetrics", "maxx"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1213:34
        { ("TTF_GetGlyphMetrics", "miny"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1213:34
        { ("TTF_GetGlyphMetrics", "maxy"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1213:34
        { ("TTF_GetGlyphMetrics", "advance"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1213:34
        { ("TTF_GetGlyphKerning", "kerning"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1231:34
        { ("TTF_GetStringSize", "w"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1253:34
        { ("TTF_GetStringSize", "h"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1253:34
        { ("TTF_GetStringSizeWrapped", "w"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1281:34
        { ("TTF_GetStringSizeWrapped", "h"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1281:34
        { ("TTF_MeasureString", "measured_width"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1309:34
        { ("TTF_MeasureString", "measured_length"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1309:34
        { ("TTF_RenderText_Solid", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1346:43
        { ("TTF_RenderText_Solid_Wrapped", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1382:43
        { ("TTF_RenderGlyph_Solid", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1411:43
        { ("TTF_RenderText_Shaded", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1449:43
        { ("TTF_RenderText_Shaded_Wrapped", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1487:43
        { ("TTF_RenderGlyph_Shaded", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1518:43
        { ("TTF_RenderText_Blended", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1554:43
        { ("TTF_RenderText_Blended_Wrapped", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1590:43
        { ("TTF_RenderGlyph_Blended", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1619:43
        { ("TTF_RenderText_LCD", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1656:43
        { ("TTF_RenderText_LCD_Wrapped", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1694:43
        { ("TTF_RenderGlyph_LCD", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1725:43
        { ("TTF_DrawSurfaceText", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1811:34
        { ("TTF_DrawSurfaceText", "surface"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1811:34
        { ("TTF_DrawRendererText", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:1901:34
        { ("TTF_GetGPUTextDrawData", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2016:56
        { ("TTF_GetGPUTextDrawData", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2016:56
        { ("TTF_CreateText", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2102:40
        { ("TTF_GetTextProperties", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2116:46
        { ("TTF_SetTextEngine", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2135:34
        { ("TTF_GetTextEngine", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2151:46
        { ("TTF_GetTextEngine", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2151:46
        { ("TTF_SetTextFont", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2174:34
        { ("TTF_GetTextFont", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2190:40
        { ("TTF_SetTextDirection", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2208:34
        { ("TTF_GetTextDirection", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2223:43
        { ("TTF_SetTextScript", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2244:34
        { ("TTF_GetTextScript", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2264:36
        { ("TTF_SetTextColor", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2287:34
        { ("TTF_SetTextColorFloat", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2310:34
        { ("TTF_GetTextColor", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2335:34
        { ("TTF_GetTextColor", "r"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2335:34
        { ("TTF_GetTextColor", "g"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2335:34
        { ("TTF_GetTextColor", "b"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2335:34
        { ("TTF_GetTextColor", "a"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2335:34
        { ("TTF_GetTextColorFloat", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2360:34
        { ("TTF_GetTextColorFloat", "r"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2360:34
        { ("TTF_GetTextColorFloat", "g"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2360:34
        { ("TTF_GetTextColorFloat", "b"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2360:34
        { ("TTF_GetTextColorFloat", "a"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2360:34
        { ("TTF_SetTextPosition", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2381:34
        { ("TTF_GetTextPosition", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2399:34
        { ("TTF_GetTextPosition", "x"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2399:34
        { ("TTF_GetTextPosition", "y"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2399:34
        { ("TTF_SetTextWrapWidth", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2419:34
        { ("TTF_GetTextWrapWidth", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2437:34
        { ("TTF_GetTextWrapWidth", "wrap_width"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2437:34
        { ("TTF_SetTextWrapWhitespaceVisible", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2462:34
        { ("TTF_TextWrapWhitespaceVisible", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2478:34
        { ("TTF_SetTextString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2501:34
        { ("TTF_InsertTextString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2528:34
        { ("TTF_AppendTextString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2551:34
        { ("TTF_DeleteTextString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2577:34
        { ("TTF_GetTextSize", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2598:34
        { ("TTF_GetTextSize", "w"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2598:34
        { ("TTF_GetTextSize", "h"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2598:34
        { ("TTF_GetTextSubString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2658:34
        { ("TTF_GetTextSubString", "substring"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2658:34
        { ("TTF_GetTextSubStringForLine", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2681:34
        { ("TTF_GetTextSubStringForLine", "substring"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2681:34
        { ("TTF_GetTextSubStringsForRange", "__return"), PointerFunctionDataIntent.Array }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2702:46
        { ("TTF_GetTextSubStringsForRange", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2702:46
        { ("TTF_GetTextSubStringsForRange", "count"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2702:46
        { ("TTF_GetTextSubStringForPoint", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2724:34
        { ("TTF_GetTextSubStringForPoint", "substring"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2724:34
        { ("TTF_GetPreviousTextSubString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2744:34
        { ("TTF_GetPreviousTextSubString", "substring"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2744:34
        { ("TTF_GetPreviousTextSubString", "previous"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2744:34
        { ("TTF_GetNextTextSubString", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2763:34
        { ("TTF_GetNextTextSubString", "substring"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2763:34
        { ("TTF_GetNextTextSubString", "next"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2763:34
        { ("TTF_UpdateText", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2781:34
        { ("TTF_DestroyText", "text"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2795:34

        //MIXER
        { ("Mix_QuerySpec", "frequency"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:319:34
        { ("Mix_QuerySpec", "channels"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:319:34
        { ("Mix_LoadWAV_IO", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:393:41
        { ("Mix_LoadWAV", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:434:41
        { ("Mix_LoadMUS", "__return"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:465:41
        { ("Mix_LoadMUS_IO", "__return"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:509:41
        { ("Mix_LoadMUSType_IO", "__return"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:566:41
        { ("Mix_QuickLoad_WAV", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:601:41
        { ("Mix_QuickLoad_WAV", "mem"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:601:41
        { ("Mix_QuickLoad_RAW", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:621:41
        { ("Mix_QuickLoad_RAW", "mem"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:621:41
        { ("Mix_FreeChunk", "chunk"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:642:34
        { ("Mix_FreeMusic", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:661:34
        { ("Mix_GetMusicType", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:809:43
        { ("Mix_GetMusicTitle", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:839:41
        { ("Mix_GetMusicTitleTag", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:866:41
        { ("Mix_GetMusicArtistTag", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:888:41
        { ("Mix_GetMusicAlbumTag", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:910:41
        { ("Mix_GetMusicCopyrightTag", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:932:41
        { ("Mix_PlayChannel", "chunk"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1552:33
        { ("Mix_PlayChannelTimed", "chunk"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1585:33
        { ("Mix_PlayMusic", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1609:34
        { ("Mix_FadeInMusic", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1637:34
        { ("Mix_FadeInMusicPos", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1677:34
        { ("Mix_FadeInChannel", "chunk"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1717:33
        { ("Mix_FadeInChannelTimed", "chunk"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1761:33
        { ("Mix_VolumeChunk", "chunk"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1817:33
        { ("Mix_GetMusicVolume", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1848:33
        { ("Mix_StartTrack", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2260:34
        { ("Mix_GetNumTracks", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2273:33
        { ("Mix_GetMusicPosition", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2301:36
        { ("Mix_MusicDuration", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2315:36
        { ("Mix_GetMusicLoopStartTime", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2330:36
        { ("Mix_GetMusicLoopEndTime", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2345:36
        { ("Mix_GetMusicLoopLengthTime", "music"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2360:36
        { ("Mix_GetChunk", "__return"), PointerFunctionDataIntent.Pointer }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2518:41

        { ("Mix_OpenAudio", "spec"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:287:34
        { ("Mix_QuerySpec", "format"), PointerFunctionDataIntent.Out }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:319:34
        { ("Mix_LoadWAV_IO", "src"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:393:41
        { ("Mix_LoadMUS_IO", "src"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:509:41
        { ("Mix_LoadMUSType_IO", "src"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:566:41
        { ("Mix_SetPostMix", "arg"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:972:34
        { ("Mix_HookMusic", "arg"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1018:34
        { ("Mix_GetMusicHookData", "__return"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1053:36
        { ("Mix_RegisterEffect", "arg"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1164:34
        { ("Mix_EachSoundFont", "data"), PointerFunctionDataIntent.IntPtr }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2472:34
    };

    internal static readonly Dictionary<string, ReturnedCharPtrMemoryOwner> ReturnedCharPtrMemoryOwners = new()
    {
        { "SDL_GetError", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_error.h:112:42
        { "SDL_GetStringProperty", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_properties.h:400:42
        { "SDL_GetThreadName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_thread.h:338:42
        { "SDL_GetAudioDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_audio.h:415:42
        { "SDL_GetCurrentAudioDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_audio.h:432:42
        { "SDL_GetAudioDeviceName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_audio.h:507:42
        { "SDL_GetAudioFormatName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_audio.h:1994:42
        { "SDL_GetPixelFormatName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_pixels.h:767:42
        { "SDL_GetCameraDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_camera.h:150:42
        { "SDL_GetCurrentCameraDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_camera.h:166:42
        { "SDL_GetCameraName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_camera.h:237:42
        { "SDL_GetClipboardText", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_clipboard.h:74:36
        { "SDL_GetPrimarySelectionText", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_clipboard.h:117:36
        { "SDL_GetVideoDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_video.h:376:42
        { "SDL_GetCurrentVideoDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_video.h:393:42
        { "SDL_GetDisplayName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_video.h:469:42
        { "SDL_GetWindowTitle", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_video.h:1344:42
        { "SDL_GetSensorNameForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_sensor.h:163:42
        { "SDL_GetSensorName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_sensor.h:233:42
        { "SDL_GetJoystickNameForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_joystick.h:231:42
        { "SDL_GetJoystickPathForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_joystick.h:247:42
        { "SDL_GetJoystickName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_joystick.h:678:42
        { "SDL_GetJoystickPath", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_joystick.h:691:42
        { "SDL_GetJoystickSerial", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_joystick.h:806:42
        { "SDL_GetGamepadMappingForGUID", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_gamepad.h:418:36
        { "SDL_GetGamepadMapping", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_gamepad.h:437:36
        { "SDL_GetGamepadNameForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:512:42
        { "SDL_GetGamepadPathForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:528:42
        { "SDL_GetGamepadMappingForID", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_gamepad.h:658:36
        { "SDL_GetGamepadName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:756:42
        { "SDL_GetGamepadPath", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:770:42
        { "SDL_GetGamepadSerial", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:891:42
        { "SDL_GetGamepadStringForType", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:1054:42
        { "SDL_GetGamepadStringForAxis", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:1090:42
        { "SDL_GetGamepadStringForButton", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:1163:42
        { "SDL_GetGamepadAppleSFSymbolsNameForButton", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:1449:42
        { "SDL_GetGamepadAppleSFSymbolsNameForAxis", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gamepad.h:1462:42
        { "SDL_GetKeyboardNameForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_keyboard.h:104:42
        { "SDL_GetScancodeName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_keyboard.h:268:42
        { "SDL_GetKeyName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_keyboard.h:299:42
        { "SDL_GetMouseNameForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_mouse.h:182:42
        { "SDL_GetTouchDeviceName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_touch.h:104:42
        { "SDL_GetBasePath", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_filesystem.h:80:42
        { "SDL_GetPrefPath", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_filesystem.h:135:36
        { "SDL_GetUserFolder", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_filesystem.h:217:42
        { "SDL_GetGPUDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gpu.h:1874:42
        { "SDL_GetGPUDeviceDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_gpu.h:1884:42
        { "SDL_GetHapticNameForID", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_haptic.h:960:42
        { "SDL_GetHapticName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_haptic.h:1022:42
        { "SDL_GetHint", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_hints.h:4151:41
        { "SDL_GetAppMetadataProperty", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_init.h:352:42
        { "SDL_GetPlatform", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_platform.h:56:42
        { "SDL_GetRenderDriver", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_render.h:172:42
        { "SDL_GetRendererName", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_render.h:354:42
        { "SDL_GetRevision", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_version.h:172:42
        { "SDL_GetGamepadMappings", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_gamepad.h:423:37
        { "SDL_GlobDirectory", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_filesystem.h:448:37
        { "SDL_GlobStorageDirectory", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_storage.h:450:37
        { "SDL_GetCurrentDirectory", ReturnedCharPtrMemoryOwner.Caller }, // /usr/local/include/SDL3/SDL_filesystem.h:489:36
        { "SDL_GetTrayEntryLabel", ReturnedCharPtrMemoryOwner.SDL }, // /usr/local/include/SDL3/SDL_tray.h:312:41

        { "TTF_GetFontFamilyName", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:897:42
        { "TTF_GetFontStyleName", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:915:42

        { "Mix_GetChunkDecoder", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:706:42
        { "Mix_GetMusicDecoder", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:773:42
        { "Mix_GetMusicTitle", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:839:41
        { "Mix_GetMusicTitleTag", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:866:41
        { "Mix_GetMusicArtistTag", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:888:41
        { "Mix_GetMusicAlbumTag", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:910:41
        { "Mix_GetMusicCopyrightTag", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:932:41
        { "Mix_GetSoundFonts", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2443:41
        { "Mix_GetTimidityCfg", ReturnedCharPtrMemoryOwner.SDL }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2506:41
    };

    internal static readonly Dictionary<string, string> ReturnedArrayCountParamNames = new()
    {
        { "SDL_GetAudioDeviceChannelMap", "count" },
        { "SDL_GetAudioStreamInputChannelMap", "count" }, // /usr/local/include/SDL3/SDL_audio.h:1136:35
        { "SDL_GetAudioStreamOutputChannelMap", "count" }, // /usr/local/include/SDL3/SDL_audio.h:1160:35
        { "SDL_GetSurfaceImages", "count" }, // /usr/local/include/SDL3/SDL_surface.h:388:44
        { "SDL_GetCameraSupportedFormats", "count" }, // /usr/local/include/SDL3/SDL_camera.h:222:47
        { "SDL_GetFullscreenDisplayModes", "count" }, // /usr/local/include/SDL3/SDL_video.h:649:48
        { "SDL_GetWindows", "count" }, // /usr/local/include/SDL3/SDL_video.h:885:43
        { "SDL_GetGamepadBindings", "count" }, // /usr/local/include/SDL3/SDL_gamepad.h:1031:51
        { "SDL_GetKeyboardState", "numkeys" }, // /usr/local/include/SDL3/SDL_keyboard.h:144:42
        { "SDL_GetTouchFingers", "count" }, // /usr/local/include/SDL3/SDL_touch.h:129:43
        { "SDL_GetPreferredLocales", "count" }, // /usr/local/include/SDL3/SDL_locale.h:101:43

        // Change from size to count so that it will omit when compare to the SDL's function with same name
        { "SDL_GetTrayEntries", "count" }, // /usr/local/include/SDL3/SDL_tray.h:240:51
        { "TTF_GetTextSubStringsForRange", "count" }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_ttf/SDL_ttf.h:2702:46
    };

    internal static readonly Dictionary<string, DelegateDefinition> DelegateDefinitions = new()
    {
        {
            "SDL_AssertionHandler",
            new DelegateDefinition { ReturnType = "SDL_AssertState", Parameters = [("SDL_AssertData*", "data"), ("IntPtr", "userdata")] }
        }, // /usr/local/include/SDL3/SDL_assert.h:423:35
        {
            "SDL_CleanupPropertyCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("IntPtr", "value")] }
        }, // /usr/local/include/SDL3/SDL_properties.h:187:24
        {
            "SDL_EnumeratePropertiesCallback",
            new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("uint", "props"), ("byte*", "name")] }
        }, // /usr/local/include/SDL3/SDL_properties.h:499:24
        {
            "SDL_ThreadFunction", new DelegateDefinition { ReturnType = "int", Parameters = [("IntPtr", "data")] }
        }, // /usr/local/include/SDL3/SDL_thread.h:113:24
        {
            "SDL_TLSDestructorCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "value")] }
        }, // /usr/local/include/SDL3/SDL_thread.h:487:24
        {
            "SDL_AudioStreamCallback",
            new DelegateDefinition
                { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("IntPtr", "stream"), ("int", "additional_amount"), ("int", "total_amount")] }
        }, // /usr/local/include/SDL3/SDL_audio.h:1527:24
        {
            "SDL_AudioPostmixCallback",
            new DelegateDefinition
                { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("SDL_AudioSpec*", "spec"), ("float*", "buffer"), ("int", "buflen")] }
        }, // /usr/local/include/SDL3/SDL_audio.h:1744:24
        {
            "SDL_ClipboardDataCallback",
            new DelegateDefinition { ReturnType = "IntPtr", Parameters = [("IntPtr", "userdata"), ("byte*", "mime_type"), ("IntPtr", "size")] }
        }, // /usr/local/include/SDL3/SDL_clipboard.h:154:31
        {
            "SDL_ClipboardCleanupCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "userdata")] }
        }, // /usr/local/include/SDL3/SDL_clipboard.h:166:24
        { "SDL_EGLAttribArrayCallback", new DelegateDefinition { ReturnType = "IntPtr", Parameters = [] } }, // /usr/local/include/SDL3/SDL_video.h:246:34
        { "SDL_EGLIntArrayCallback", new DelegateDefinition { ReturnType = "IntPtr", Parameters = [] } }, // /usr/local/include/SDL3/SDL_video.h:247:31
        {
            "SDL_HitTest",
            new DelegateDefinition { ReturnType = "SDL_HitTestResult", Parameters = [("IntPtr", "win"), ("SDL_Point*", "area"), ("IntPtr", "data")] }
        }, // /usr/local/include/SDL3/SDL_video.h:2328:37
        {
            "SDL_DialogFileCallback",
            new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("IntPtr", "filelist"), ("int", "filter")] }
        }, // /usr/local/include/SDL3/SDL_dialog.h:97:24
        {
            "SDL_EventFilter", new DelegateDefinition { ReturnType = "bool", Parameters = [("IntPtr", "userdata"), ("SDL_Event*", "evt")] }
        }, // /usr/local/include/SDL3/SDL_events.h:1283:24
        {
            "SDL_EnumerateDirectoryCallback",
            new DelegateDefinition { ReturnType = "SDL_EnumerationResult", Parameters = [("IntPtr", "userdata"), ("byte*", "dirname"), ("byte*", "fname")] }
        }, // /usr/local/include/SDL3/SDL_filesystem.h:302:41
        {
            "SDL_HintCallback",
            new DelegateDefinition
                { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("byte*", "name"), ("byte*", "oldValue"), ("byte*", "newValue")] }
        }, // /usr/local/include/SDL3/SDL_hints.h:4189:23
        {
            "SDL_AppInit_func",
            new DelegateDefinition { ReturnType = "SDL_AppResult", Parameters = [("IntPtr", "appstate"), ("int", "argc"), ("IntPtr", "argv")] }
        }, // /usr/local/include/SDL3/SDL_init.h:96:33
        {
            "SDL_AppIterate_func", new DelegateDefinition { ReturnType = "SDL_AppResult", Parameters = [("IntPtr", "appstate")] }
        }, // /usr/local/include/SDL3/SDL_init.h:97:33
        {
            "SDL_AppEvent_func", new DelegateDefinition { ReturnType = "SDL_AppResult", Parameters = [("IntPtr", "appstate"), ("SDL_Event*", "evt")] }
        }, // /usr/local/include/SDL3/SDL_init.h:98:33
        {
            "SDL_AppQuit_func", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "appstate"), ("SDL_AppResult", "result")] }
        }, // /usr/local/include/SDL3/SDL_init.h:99:24
        {
            "SDL_LogOutputFunction",
            new DelegateDefinition
                { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("int", "category"), ("SDL_LogPriority", "priority"), ("byte*", "message")] }
        }, // /usr/local/include/SDL3/SDL_log.h:474:24
        {
            "SDL_TimerCallback",
            new DelegateDefinition { ReturnType = "uint", Parameters = [("IntPtr", "userdata"), ("uint", "timerID"), ("uint", "interval")] }
        }, // /usr/local/include/SDL3/SDL_timer.h:158:26
        {
            "SDL_NSTimerCallback",
            new DelegateDefinition { ReturnType = "ulong", Parameters = [("IntPtr", "userdata"), ("uint", "timerID"), ("ulong", "interval")] }
        }, // /usr/local/include/SDL3/SDL_timer.h:220:26
        {
            "SDL_main_func", new DelegateDefinition { ReturnType = "int", Parameters = [("int", "argc"), ("IntPtr", "argv")] }
        }, // /usr/local/include/SDL3/SDL_main.h:399:23
        {
            "SDL_MainThreadCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "userdata")] }
        }, // /usr/local/include/SDL3/SDL_init.h:331:24
        {
            "SDL_TrayCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "userdata"), ("IntPtr", "entry")] }
        }, // /usr/local/include/SDL3/SDL_tray.h:93:24

        //mixer
        { "Mix_MixCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("IntPtr", "udata"),("byte*","stream"),("int","len")]} }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:934:24
        { "Mix_MusicFinishedCallback", new DelegateDefinition { ReturnType = "void", Parameters = [] } }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1020:24
        { "Mix_ChannelFinishedCallback", new DelegateDefinition { ReturnType = "void", Parameters = [("int","channel")] } }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1055:24
        { "Mix_EffectFunc_t", new DelegateDefinition { ReturnType = "void", Parameters = [("int","chan"),("IntPtr","stream"),("int","len"),("IntPtr","udata")] } }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1095:24
        { "Mix_EffectDone_t", new DelegateDefinition { ReturnType = "void", Parameters = [("int","chan"),("IntPtr","udata")] } }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:1105:24
        { "Mix_EachSoundFontCallback", new DelegateDefinition { ReturnType = "bool", Parameters = [("string","path"),("IntPtr","data")] } }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:2445:24
    };

    internal static readonly Dictionary<string, string[]> FlagEnumDefinitions = new()
    {
        {
            "SDL_SurfaceFlags", [
                "SDL_SURFACE_PREALLOCATED",
                "SDL_SURFACE_LOCK_NEEDED",
                "SDL_SURFACE_LOCKED",
                "SDL_SURFACE_SIMD_ALIGNED",
            ]
        }, // ./include/SDL3/SDL_surface.h:52:16
        {
            "SDL_WindowFlags", [
                "SDL_WINDOW_FULLSCREEN",
                "SDL_WINDOW_OPENGL",
                "SDL_WINDOW_OCCLUDED",
                "SDL_WINDOW_HIDDEN",
                "SDL_WINDOW_BORDERLESS",
                "SDL_WINDOW_RESIZABLE",
                "SDL_WINDOW_MINIMIZED",
                "SDL_WINDOW_MAXIMIZED",
                "SDL_WINDOW_MOUSE_GRABBED",
                "SDL_WINDOW_INPUT_FOCUS",
                "SDL_WINDOW_MOUSE_FOCUS",
                "SDL_WINDOW_EXTERNAL",
                "SDL_WINDOW_MODAL",
                "SDL_WINDOW_HIGH_PIXEL_DENSITY",
                "SDL_WINDOW_MOUSE_CAPTURE",
                "SDL_WINDOW_MOUSE_RELATIVE_MODE",
                "SDL_WINDOW_ALWAYS_ON_TOP",
                "SDL_WINDOW_UTILITY",
                "SDL_WINDOW_TOOLTIP",
                "SDL_WINDOW_POPUP_MENU",
                "SDL_WINDOW_KEYBOARD_GRABBED",
                // unused bits between "KeyboardGrabbed" and "Vulkan"
                "SDL_WINDOW_VULKAN = 0x10000000",
                "SDL_WINDOW_METAL = 0x20000000",
                "SDL_WINDOW_TRANSPARENT = 0x40000000",
                "SDL_WINDOW_NOT_FOCUSABLE = 0x080000000",
            ]
        }, // ./include/SDL3/SDL_video.h:158:16
        {
            "SDL_MouseButtonFlags", [
                "SDL_BUTTON_LMASK",
                "SDL_BUTTON_MMASK",
                "SDL_BUTTON_RMASK",
                "SDL_BUTTON_X1MASK",
                "SDL_BUTTON_X2MASK",
            ]
        }, // ./include/SDL3/SDL_mouse.h:118:16
        {
            "SDL_PenInputFlags", [
                "SDL_PEN_INPUT_DOWN",
                "SDL_PEN_INPUT_BUTTON_1",
                "SDL_PEN_INPUT_BUTTON_2",
                "SDL_PEN_INPUT_BUTTON_3",
                "SDL_PEN_INPUT_BUTTON_4",
                "SDL_PEN_INPUT_BUTTON_5",
                "SDL_PEN_INPUT_ERASER_TIP = 0x40000000",
            ]
        }, // ./include/SDL3/SDL_pen.h:68:16
        {
            "SDL_GlobFlags", [
                "SDL_GLOB_CASEINSENSITIVE",
            ]
        }, // ./include/SDL3/SDL_filesystem.h:261:16
        {
            "SDL_GPUTextureUsageFlags", [
                "SDL_GPU_TEXTUREUSAGE_SAMPLER",
                "SDL_GPU_TEXTUREUSAGE_COLOR_TARGET",
                "SDL_GPU_TEXTUREUSAGE_DEPTH_STENCIL_TARGET",
                "SDL_GPU_TEXTUREUSAGE_GRAPHICS_STORAGE_READ",
                "SDL_GPU_TEXTUREUSAGE_COMPUTE_STORAGE_READ",
                "SDL_GPU_TEXTUREUSAGE_COMPUTE_STORAGE_WRITE",
            ]
        }, // ./include/SDL3/SDL_gpu.h
        {
            "SDL_GPUBufferUsageFlags", [
                "SDL_GPU_BUFFERUSAGE_VERTEX",
                "SDL_GPU_BUFFERUSAGE_INDEX",
                "SDL_GPU_BUFFERUSAGE_INDIRECT",
                "SDL_GPU_BUFFERUSAGE_GRAPHICS_STORAGE_READ",
                "SDL_GPU_BUFFERUSAGE_COMPUTE_STORAGE_READ",
                "SDL_GPU_BUFFERUSAGE_COMPUTE_STORAGE_WRITE",
            ]
        }, // ./include/SDL3/SDL_gpu.h
        {
            "SDL_GPUColorComponentFlags", [
                "SDL_GPU_COLORCOMPONENT_R",
                "SDL_GPU_COLORCOMPONENT_G",
                "SDL_GPU_COLORCOMPONENT_B",
                "SDL_GPU_COLORCOMPONENT_A",
            ]
        }, // ./include/SDL3/SDL_gpu.h
        {
            "SDL_GPUShaderFormat", [
                "SDL_GPU_SHADERFORMAT_PRIVATE",
                "SDL_GPU_SHADERFORMAT_SPIRV",
                "SDL_GPU_SHADERFORMAT_DXBC",
                "SDL_GPU_SHADERFORMAT_DXIL",
                "SDL_GPU_SHADERFORMAT_MSL",
                "SDL_GPU_SHADERFORMAT_METALLIB"
            ]
        }, // ./include/SDL3/SDL_gpu.h:615
        {
            "SDL_InitFlags", [
                "SDL_INIT_TIMER = 0x1",
                "SDL_INIT_AUDIO = 0x10",
                "SDL_INIT_VIDEO = 0x20",
                "SDL_INIT_JOYSTICK = 0x200",
                "SDL_INIT_HAPTIC = 0x1000",
                "SDL_INIT_GAMEPAD = 0x2000",
                "SDL_INIT_EVENTS = 0x4000",
                "SDL_INIT_SENSOR = 0x08000",
                "SDL_INIT_CAMERA = 0x10000",
            ]
        }, // ./include/SDL3/SDL_init.h:58:16
        {
            "SDL_MessageBoxFlags", [
                "SDL_MESSAGEBOX_ERROR = 0x10",
                "SDL_MESSAGEBOX_WARNING = 0x20",
                "SDL_MESSAGEBOX_INFORMATION = 0x40",
                "SDL_MESSAGEBOX_BUTTONS_LEFT_TO_RIGHT = 0x080",
                "SDL_MESSAGEBOX_BUTTONS_RIGHT_TO_LEFT = 0x100",
            ]
        }, // ./include/SDL3/SDL_messagebox.h:48:16
        {
            "SDL_MessageBoxButtonFlags", [
                "SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT",
                "SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT",
            ]
        }, // ./include/SDL3/SDL_messagebox.h:61:16
        {
            "SDL_Keymod", [
                "SDL_KMOD_NONE = 0x0000",
                "SDL_KMOD_LSHIFT = 0x0001",
                "SDL_KMOD_RSHIFT = 0x0002",
                "SDL_KMOD_LCTRL = 0x0040",
                "SDL_KMOD_RCTRL = 0x0080",
                "SDL_KMOD_LALT = 0x0100",
                "SDL_KMOD_RALT = 0x0200",
                "SDL_KMOD_LGUI = 0x0400",
                "SDL_KMOD_RGUI = 0x0800",
                "SDL_KMOD_NUM = 0x1000",
                "SDL_KMOD_CAPS = 0x2000",
                "SDL_KMOD_MODE = 0x4000",
                "SDL_KMOD_SCROLL = 0x8000",
                "SDL_KMOD_CTRL = SDL_KMOD_LCTRL | SDL_KMOD_RCTRL",
                "SDL_KMOD_SHIFT = SDL_KMOD_LSHIFT | SDL_KMOD_RSHIFT",
                "SDL_KMOD_ALT = SDL_KMOD_RALT | SDL_KMOD_LALT",
                "SDL_KMOD_GUI = SDL_KMOD_RGUI | SDL_KMOD_LGUI",
            ]
        }, // ../SDL3/SDL_keycode.h:306:16
        {
            "SDL_TrayEntryFlags", [
                "SDL_TRAYENTRY_BUTTON = 0x00000001u",
                "SDL_TRAYENTRY_CHECKBOX = 0x00000002u",
                "SDL_TRAYENTRY_SUBMENU = 0x00000004u",
                "SDL_TRAYENTRY_DISABLED = 0x80000000u",
                "SDL_TRAYENTRY_CHECKED = 0x40000000u"
            ]
        }, // /usr/local/include/SDL3/SDL_tray.h:74:16
        // {
        //     "IMG_AnimationDecoderStatus", [
        //         "IMG_DECODER_STATUS_INVALID = -1",    /**< The decoder is invalid */
        //         "IMG_DECODER_STATUS_OK",              /**< The decoder is ready to decode the next frame */
        //         "IMG_DECODER_STATUS_FAILED",          /**< The decoder failed to decode a frame, call SDL_GetError() for more information. */
        //         "IMG_DECODER_STATUS_COMPLETE"         /**< No more frames available */
        //     ]
        // }, //NO!!
        //{
        //     "TTF_DrawCommand", [
        //         "TTF_DRAW_COMMAND_NOOP",
        //         "TTF_DRAW_COMMAND_FILL",
        //         "TTF_DRAW_COMMAND_COPY"
        //     ]
        // },
        // {
        //     "TTF_HorizontalAlignment", [
        //         "TTF_HORIZONTAL_ALIGN_INVALID = -1",
        //         "TTF_HORIZONTAL_ALIGN_LEFT",
        //         "TTF_HORIZONTAL_ALIGN_CENTER",
        //         "TTF_HORIZONTAL_ALIGN_RIGHT"
        //     ]
        // },
        // {
        //     "TTF_Direction", [
        //         "TTF_DIRECTION_INVALID = 0",
        //         "TTF_DIRECTION_LTR = 4",        /**< Left to Right */
        //         "TTF_DIRECTION_RTL",            /**< Right to Left */
        //         "TTF_DIRECTION_TTB",            /**< Top to Bottom */
        //         "TTF_DIRECTION_BTT"             /**< Bottom to Top */
        //     ]
        // },
        // {
        //     "TTF_ImageType", [
        //         "TTF_IMAGE_INVALID",
        //         "TTF_IMAGE_ALPHA",    /**< The color channels are white */
        //         "TTF_IMAGE_COLOR",    /**< The color channels have image data */
        //         "TTF_IMAGE_SDF",      /**< The alpha channel has signed distance field information */
        //     ]
        // },
        // {
        //     "TTF_GPUTextEngineWinding", [
        //         "TTF_GPU_TEXTENGINE_WINDING_INVALID = -1",
        //         "TTF_GPU_TEXTENGINE_WINDING_CLOCKWISE",
        //         "TTF_GPU_TEXTENGINE_WINDING_COUNTER_CLOCKWISE"
        //     ]
        // },   //duplicate enums
        {
            "TTF_FontStyleFlags", [
                "TTF_STYLE_NORMAL        = 0x00", /**< No special style */
                "TTF_STYLE_BOLD          = 0x01", /**< Bold style */
                "TTF_STYLE_ITALIC        = 0x02", /**< Italic style */
                "TTF_STYLE_UNDERLINE     = 0x04", /**< Underlined text */
                "TTF_STYLE_STRIKETHROUGH = 0x08" /**< Strikethrough text */
            ]
        },
        {
            "TTF_SubStringFlags", [
                "TTF_SUBSTRING_DIRECTION_MASK  =  0x000000FF",  /**< The mask for the flow direction for this substring */
                "TTF_SUBSTRING_TEXT_START      =  0x00000100",  /**< This substring contains the beginning of the text */
                "TTF_SUBSTRING_LINE_START      =  0x00000200",  /**< This substring contains the beginning of line `line_index` */
                "TTF_SUBSTRING_LINE_END        =  0x00000400",  /**< This substring contains the end of line `line_index` */
                "TTF_SUBSTRING_TEXT_END        =  0x00000800"  /**< This substring contains the end of the text */
                    ]
        },
        { "MIX_InitFlags", [
            "MIX_INIT_FLAC     =  0x00000001",
            "MIX_INIT_MOD       = 0x00000002",
            "MIX_INIT_MP3       = 0x00000008",
            "MIX_INIT_OGG       = 0x00000010",
            "MIX_INIT_MID       = 0x00000020",
            "MIX_INIT_OPUS      = 0x00000040",
            "MIX_INIT_WAVPACK   = 0x00000080" 
        ] }, // /home/khoa-deb/SDL3-CS/SDL3-release/include/SDL3_mixer/SDL_mixer.h:75:16
    };

    internal static readonly HashSet<string> FlagTypes =
    [
        "SDL_Keymod",
        "SDL_GPUShaderFormat",
    ];

    internal static readonly string[] DeniedTypes = [];
}
