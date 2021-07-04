using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public CharacterController2D CharacterController2D;
    public PlayerMovement PlayerMovement;
    public float timeForEachPoint;
    public gameManager gameManager;
    public int iscore=0;
    private float timer;
        public float speedDecrease;

    public TMP_Text scoreDisplay;
    public GameObject player;
    private  AudioSource audio;
    public AudioClip jumpSound;
 public AudioClip deathSound;
 public AudioClip backgroundMusic;
 AudioSource myAudioSource1;
 public AudioSource myAudioSource2;
 AudioSource myAudioSource3;
 
    // Start is called before the first frame update

 
    void Start()
    {
        CharacterController2D=player.GetComponent<CharacterController2D>();
        PlayerMovement=player.GetComponent<PlayerMovement>();
        timer=timeForEachPoint;
        myAudioSource1 = AddAudio (false, false, 0.4f);
     myAudioSource2 = AddAudio (false, false, 1f);
     myAudioSource3 = AddAudio (true, false, 0.3f);
     StartPlayingSounds ();

    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol) 
 { 
     AudioSource newAudio = gameObject.AddComponent<AudioSource>();
     //newAudio.clip = clip; 
     newAudio.loop = loop;
     newAudio.playOnAwake = playAwake;
     newAudio.volume = vol; 
     return newAudio; 
 }
 void StartPlayingSounds()
 {
     myAudioSource1.clip = jumpSound;
    // myAudioSource1.Play ();
     myAudioSource2.clip = deathSound;
   //  myAudioSource2.Play ();
      myAudioSource3.clip = backgroundMusic;
     myAudioSource3.Play ();
     //and so on
 }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.SetText(iscore.ToString());
      
        if(player!=null)
        {
            if (CharacterController2D.m_Grounded && PlayerMovement.jump)
            {
                myAudioSource1.Play ();
            }
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
            gameManager.OnLose();
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
