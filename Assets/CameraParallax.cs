using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParallax : MonoBehaviour
{
   // public GameObject envirenment;
    public Camera mainCam;
    public float upYpos;

   
    // Update is called once per frame
    void Start()
    {
        mainCam = Camera.main;
    }
    private void OnBecameInvisible()
    {
        Vector2 upPos = new Vector2(transform.position.x, mainCam.transform.position.y + upYpos);
        transform.position = upPos;
            }
}