using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float dropHeight = 10;
    public float dropTime;
    private float timeTillDrop;
    public float minX;
    public float maxX;

    public float dropDepth = 2;
    public GameObject debris;
    // Update is called once per frame
    private void Start() {
        timeTillDrop = dropTime;
    }
    void Update()
    {
        timeTillDrop-= Time.deltaTime;

        if(timeTillDrop <=0 )
        {
            gameObject.transform.position = new Vector3(Random.Range(minX, maxX), dropHeight, dropDepth);
            Instantiate(debris, transform);
            timeTillDrop = dropTime;
        }
    }
}
