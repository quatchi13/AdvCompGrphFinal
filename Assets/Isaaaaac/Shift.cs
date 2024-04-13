using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public float shiftTime;

    public float shrinkTime;

    private bool shifting = false;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Debris")
        {
            if(!shifting)
            {
                shifting = true;
                StartCoroutine("ShiftBits");
            }
        }
    } 
        
     private void Update() {
        if(transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShiftBits()
    {
        float t = 0;
        while(t <=1.0f)
        {
            Debug.Log("fading");
            t += Time.deltaTime / shiftTime;
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_Shift", t);
            yield return null;
        }
        StartCoroutine("ShrinkBits");
    }


    IEnumerator ShrinkBits()
    {
        
        float t = 1;
        while(t >=0.98f)
        {
            Debug.Log("fading");
            t -= Time.deltaTime / shrinkTime;
            transform.localScale *= t; //make t*2 for funny bug
            yield return null;
        }
        Destroy(gameObject);
    }
}
