using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAssignment : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        gameObject.GetComponent<Button>().onClick.AddListener(FindObjectOfType<SceneControl>().GetComponent<SceneControl>().action);
    }

}
