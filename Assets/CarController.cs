using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    public bool hasSwiped = false;
    public bool hasStopped = false;
    public bool hasPause = false; 

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
        this.Init();       
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPause) {
            if (Input.GetMouseButtonUp(0)) {
                hasPause = false;
            }
            return;
        }
        
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

            GetComponent<AudioSource>().Play();
        }

        if (hasSwiped && !hasStopped)
        {
            transform.Translate(this.speed, 0, 0);
            this.speed *= 0.98f;
            if (Math.Floor(this.speed * 10000) == 0)
            {
                this.speed = 0;
                this.hasStopped = true;
            }        
        }
    }

    public void Init()
    {
        this.hasSwiped = false;
        this.hasStopped = false;
        this.speed = 0;
        Vector2 initPos = new Vector2(-7f, -3.7f);
        this.transform.position = initPos;
        
        if (Input.GetMouseButtonDown(0)) {
            hasPause = true;
        }
    }
}
