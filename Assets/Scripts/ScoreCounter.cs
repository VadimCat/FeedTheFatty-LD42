using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

    FoodScr foodScr;
    private Events events;

    private void Start()
    {
        events = GameObject.Find("EventSystem").GetComponent<Events>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foodScr = collision.gameObject.GetComponent<FoodScr>();
        Debug.Log(collision.gameObject.name);
    }
}
