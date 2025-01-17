﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float speed;
    public float speedIncrease;
    public float speedLimit;
    public float timeToIncrease;
    public PlayerMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.jumpPressed)
        {
           transform.Translate(Vector3.up * Time.deltaTime * speed);
           if (timeToIncrease<=0f)
           {
               if(speed<speedLimit)
               {
                   speed+=speedIncrease;
               }
               timeToIncrease=1f;
           }
           else 
           {
               timeToIncrease-=Time.deltaTime;
           }
        }
    }
}
