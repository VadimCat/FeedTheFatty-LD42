using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScr : MonoBehaviour {

    private bool dragging = false;
    private float distance;
    private Vector3 startpos;
    private Quaternion startquat;
    bool IsColl = false;
    public int KiloCalories;
    [HideInInspector] public bool Eaten = false;

    [HideInInspector] public Events events;

    private void Start()
    {
        events = GameObject.Find("EventSystem").GetComponent<Events>();
    }

    private void OnTriggerStay(Collider other)
    {
        IsColl = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsColl = false;
    }

    void OnMouseDown()
    {
        startpos = this.transform.position;
        startquat = this.transform.rotation;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
    
        void OnMouseUp()
    {
        dragging = false;
        if (IsColl)
        {
            this.transform.position = startpos;
            this.transform.rotation = startquat;
        }
    }

    void Update()
    {
        if (dragging&&events.CanU)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.y = this.transform.position.y;
            transform.position = rayPoint;

            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                this.transform.Rotate(Vector3.up * 15);
            }
            else if (d < 0f)
            {
                this.transform.Rotate(Vector3.up * -15);
            }
        }
    }
}