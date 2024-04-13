using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{

    public float fadeTime;

    private bool fading = false;


    private void Update() {
        if(transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Debris")
        {
            if(!fading)
            {
                fading = true;
                StartCoroutine("FadeBits");
            }
        }
    } 
        
    

    IEnumerator FadeBits()
    {
        yield return new WaitForSeconds(1.0f);
        float t = 0;
        while(t <=1.0f)
        {
            Debug.Log("fading");
            t += Time.deltaTime / fadeTime *10;
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_Dissolve", t);
            yield return null;
        }
        Destroy(gameObject);
    }
}
