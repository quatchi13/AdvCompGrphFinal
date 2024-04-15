using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

using System;
using System.Collections;
using System.Collections.Generic;

public class PixelizeFeature : ScriptableRendererFeature
{
    float timer;

    public float lerpSpeed = 2;

    public static PixelizeFeature pixelizeFeatureInstance;

    [System.Serializable]
    public class CustomPassSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        public int resolution = 64;
    }

    [SerializeField] private CustomPassSettings settings;
    private PixelizePass customPass;

    public override void Create()
    {
        pixelizeFeatureInstance = this;
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
        timer = 0;

        while (timer < 5)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            settings.resolution = (int)Mathf.Lerp(16, 600, timer / 5);
            timer += Time.deltaTime * lerpSpeed;
        }

        Debug.Log("Finished");

        yield return null;
    }

    public IEnumerator LerpOut()
    {
        timer = 0;

        while (timer < 5)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            settings.resolution = (int)Mathf.Lerp(600, 16, timer / 5);
            timer += Time.deltaTime * lerpSpeed;
        }

        Debug.Log("Finished");

        SceneControl.instance.Swap();
        

        /*timer = 0;

        while (timer < 5)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            settings.resolution = (int)Mathf.Lerp(16, 600, timer / 5);
            timer += Time.deltaTime * lerpSpeed;
        }*/


        yield return null;
    }
}

