using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSys : MonoBehaviour {


    public GameObject Fade;
    void Start () {
        Fade.SetActive(true);
        StartCoroutine(FadeOff());
    }

    public IEnumerator FadeOff()
    {
        yield return new WaitForSeconds(1f);
        Fade.SetActive(false);
    }

}
