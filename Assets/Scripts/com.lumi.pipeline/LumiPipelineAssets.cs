using System.Collections;
using System.Collections.Generic;
using com.lumi.pipeline;
using UnityEngine;
using UnityEngine.Rendering;

public class LumiPipelineAssets : RenderPipelineAsset
{
    protected override RenderPipeline CreatePipeline()
    {
        return new LumiPipeline();
    }
}
