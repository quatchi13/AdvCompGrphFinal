using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BananaChoice : MonoBehaviour
{
    public void ToDeath()
    {
        SceneManager.LoadScene(6);
    }

    public void ToFren()
    {
        SceneManager.LoadScene(7);
    }
}
