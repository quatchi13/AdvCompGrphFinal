using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelizeLerp : MonoBehaviour
{
    public void Test()
    {
        //StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpIn());

        PixelizeFeature newEvent = new PixelizeFeature();
        StartCoroutine(newEvent.LerpIn());

        //newEvent.GoUp();
    }
}
