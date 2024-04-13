using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControl : MonoBehaviour
{
    public SceneControl instance;

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

        StartCoroutine(FadeToBlack.fadeInstance.Fade());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(randomScene);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FadeToBlack.fadeInstance.Fade(false));
        }

        numMoves++;

        yield return null;
    }

    public IEnumerator PlayGame()
    {
        FadeToBlack.fadeInstance.Fade(true, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
        yield return new WaitForSeconds(0.5f);
        FadeToBlack.fadeInstance.Fade(false, 1);
        yield return null;
    }

    public IEnumerator Banana() // Whichever scene the win banana is on
    {
        FadeToBlack.fadeInstance.Fade(true, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(7);
        yield return new WaitForSeconds(0.5f);
        FadeToBlack.fadeInstance.Fade(false, 1);
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
