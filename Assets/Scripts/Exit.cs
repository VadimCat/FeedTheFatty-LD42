using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour {

    // Use this for initialization
    private void OnMouseDown()
    {
        Debug.Log("СРДУТ");
        Application.Quit();
    }
}
