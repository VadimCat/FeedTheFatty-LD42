using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
