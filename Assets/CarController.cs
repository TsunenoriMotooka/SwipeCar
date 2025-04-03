using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    bool hasSwiped = false;
    public bool hasStopped = false; 

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSwiped && Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
            print(this.startPos);
        }
        if (!hasSwiped && Input.GetMouseButtonUp(0))
        {
            hasSwiped = true;
            Vector2 endPos = Input.mousePosition;
            float swipeLength = Mathf.Max(0, endPos.x - this.startPos.x);

            this.speed = swipeLength / 500f;
        }

        if (hasSwiped && !hasStopped)
        {
            transform.Translate(this.speed, 0, 0);
            this.speed *= 0.98f;
            if (Math.Floor(this.speed * 1000) == 0)
            {
                this.speed = 0;
                this.hasStopped = true;
            }        
        }
    }
}
