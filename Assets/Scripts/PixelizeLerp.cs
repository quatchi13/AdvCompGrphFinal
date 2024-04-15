using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelizeLerp : MonoBehaviour
{
    public static PixelizeLerp instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }


        //StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpIn());
    }

    public void LerpIn()
    {
        StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpIn());
    }

    public void LerpOut()
    {
        StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpOut());
    }
}
