using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

using System;
using System.Collections;
using System.Collections.Generic;

public class PixelizeFeature : ScriptableRendererFeature
{
    static float timer = 5;

    public float lerpSpeed = 2;

    public static PixelizeFeature pixelizeFeatureInstance;

    private void Awake()
    {
        if (!pixelizeFeatureInstance)
        {
            pixelizeFeatureInstance = this;
        }
    }

    [System.Serializable]
    public class CustomPassSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        public int screenHeight = 64;
    }

    [SerializeField] private CustomPassSettings settings;
    private PixelizePass customPass;

    public override void Create()
    {
        customPass = new PixelizePass(settings);
    }
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {

#if UNITY_EDITOR
        if (renderingData.cameraData.isSceneViewCamera) return;
#endif
        renderer.EnqueuePass(customPass);
    }

    public IEnumerator LerpIn()
    {
        while (timer < 5)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            settings.screenHeight = (int)Mathf.Lerp(64, 1920, timer / 5);
            timer += Time.deltaTime * lerpSpeed;
        }

        yield return null;
    }

    public IEnumerator LerpOut()
    {
        while (timer < 5)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            settings.screenHeight = (int)Mathf.Lerp(1920, 64, timer / 5);
            timer += Time.deltaTime * lerpSpeed;
        }

        yield return null;
    }

    public void GoUp()
    {
        settings.screenHeight++;
    }
}

