using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public string SceneName;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneName);
    }
}