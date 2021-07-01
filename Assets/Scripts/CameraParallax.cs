using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraParallax : MonoBehaviour
{
    //public GameObject envirenment;
    public Camera mainCam;
    public float upYpos;
    public bool visible;
    public GameObject[] grounds;
    public float maxScale;
    public float minScale;
    public float maxPos;
    public float minPos;
   
    // Update is called once per frame
    void Start()
    {
        mainCam = Camera.main;
          foreach (GameObject objet in grounds)
            {
                float oldYpos = objet.transform.localPosition.y;
                objet.transform.localScale = new Vector3(Random.Range(minScale, maxScale), transform.localScale.y, transform.localScale.z);
                objet.transform.localPosition = new Vector3(Random.Range(minPos,maxPos),oldYpos,0f);
            }

    }

    private void Update()
    {
        if(mainCam.transform.position.y >= transform.position.y + upYpos)
        {
            Vector2 upPos = new Vector2(transform.position.x, mainCam.transform.position.y + upYpos);
        transform.position = upPos;

        foreach (GameObject objet in grounds)
            {
                float oldYpos = objet.transform.localPosition.y;
                objet.transform.localScale = new Vector3(Random.Range(minScale, maxScale), transform.localScale.y, transform.localScale.z);
                objet.transform.localPosition = new Vector3(Random.Range(minPos,maxPos),oldYpos,0f);
            }

        }
        
    }

     void OnBecameInvisible()
    {
        
        visible = false;

    }
    void OnBecameVisible()
    {
        visible = true;
    }

}
