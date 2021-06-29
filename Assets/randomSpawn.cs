using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    public float upYpos;
    private Camera mainCam;
    public float maxScale;
    public float minScale;
    public float maxPos;
    public float minPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.transform.position.y >= transform.position.y + upYpos)
        {
            Vector2 changePos = new Vector2(Random.Range(minPos,maxPos), mainCam.transform.position.y + upYpos);
            transform.position = changePos;
            Vector2 changeScale = new Vector3(Random.Range(minScale,maxScale), transform.localScale.y, transform.localScale.z);
            transform.localScale = changeScale;
        }
    }
}
