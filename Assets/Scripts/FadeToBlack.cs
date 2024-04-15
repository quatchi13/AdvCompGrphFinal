using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack fadeInstance;

    public GameObject blackSquare;

    public IEnumerator Fade(bool fadeToBlack = true, int speed = 5)
    {
        Color objectColour = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            blackSquare.GetComponentInParent<Canvas>().sortingOrder = 1;
            Debug.Log("Activated");
            while (blackSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColour.a + (speed * Time.deltaTime);

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                blackSquare.GetComponent<Image>().color = objectColour;

                //Pixelation.pixelationInstance.TransitionScene();

                yield return null;
            }
        }
        else
        {
            while (blackSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColour.a - (speed * Time.deltaTime);

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                blackSquare.GetComponent<Image>().color = objectColour;

                yield return null;
            }
            blackSquare.GetComponentInParent<Canvas>().sortingOrder = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(Fade());
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(Fade(false));
        }
    }

    private void Awake()
    {
        if(!fadeInstance)
        {
            fadeInstance = this;
        }

        StartCoroutine(Fade(false));
    }
}
