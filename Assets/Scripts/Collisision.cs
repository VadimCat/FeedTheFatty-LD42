using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisision : MonoBehaviour {

    FoodScr foodScr;
    public Events events;

    private void Start()
    {
        events = GameObject.Find("EventSystem").GetComponent<Events>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (events.eat)
        {
            foodScr = other.gameObject.GetComponent<FoodScr>();
            if (!foodScr.Eaten)
            {
                events.Score += foodScr.KiloCalories;
                foodScr.Eaten = true;
            }
            Destroy(other.gameObject, Random.Range(0.5f, 5));
        }
    }

}
