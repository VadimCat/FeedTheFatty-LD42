using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.y = this.transform.position.y;
        this.transform.position = pos;
    }
}
