using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControl : MonoBehaviour
{
    public static SceneControl instance;

    public GameObject fade;
    public int numMoves = 0;

    public int maxMoves = 20;

    public int minMoves = 10;

    public UnityAction action;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(fade);
        }

        action = Swap;
    }
    public IEnumerator Move()
    {
        int randomScene = Random.Range(2,5);
        
        if(numMoves >= maxMoves)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            while (randomScene == SceneManager.GetActiveScene().buildIndex)
            {
                randomScene = Random.Range(2,6);
            }

            StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpOut());
            //yield return new WaitForSeconds(5);
            SceneManager.LoadScene(randomScene);
            //yield return new WaitForSeconds(5);
            StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpIn());

        }

        numMoves++;

        yield return null;
    }

    public IEnumerator PlayGame()
    {
        StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpOut());

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
        yield return new WaitForSeconds(0);
        StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpIn());
        yield return null;
    }

    public IEnumerator Banana() // Whichever scene the win banana is on
    {
        StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpOut());

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(7);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PixelizeFeature.pixelizeFeatureInstance.LerpIn());
        yield return null;
    }

    public void Swap()
    {
        StartCoroutine(Move());
    }

     public void Begin()
    {
        StartCoroutine(PlayGame());
    }
}
