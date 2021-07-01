using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public float timeForEachPoint;
    public int iscore=0;
    private float timer;
        public float speedDecrease;

    public TMP_Text scoreDisplay;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timer=timeForEachPoint;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.SetText(iscore.ToString());


        if(player!=null)
        {
        if(timer<=0f)
        {
            iscore++;
            timer=timeForEachPoint;
        }
        else
        {
            timer-=Time.deltaTime;
        }
        }
        else
        {
            if(GetComponent<CameraFollower>().speed > 0f)
            {
                GetComponent<CameraFollower>().speed -= speedDecrease;
            }
            else
            {
                GetComponent<CameraFollower>().speed = 0f;
            }
        }
    }
}
