using UnityEngine;
using UnityEngine.Rendering;

namespace com.lumi.pipeline
{
    public class LumiPipeline: RenderPipeline
    {
        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            foreach (var camera in cameras)
            {
                Render(context, camera);
            }
        }

        protected void Render(ScriptableRenderContext context, Camera camera)
        {
            context.SetupCameraProperties(camera);

            var buffer = new CommandBuffer();
            CameraClearFlags clearFlags = camera.clearFlags;
            buffer.ClearRenderTarget(
                (clearFlags & CameraClearFlags.Depth) != 0,
                (clearFlags & CameraClearFlags.Color) != 0,
                camera.backgroundColor);
            
            context.ExecuteCommandBuffer(buffer);
            buffer.Release();

            ScriptableCullingParameters cullingParameters;
            

            context.DrawSkybox(camera);
            context.Submit();
        }
    }
}