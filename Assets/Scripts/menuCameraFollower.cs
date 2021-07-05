using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuCameraFollower : MonoBehaviour
{
    public float speed;
    public float speedIncrease;
    public float speedLimit;
    public float timeToIncrease;
    public GameObject sfxOn;
    public GameObject sfxOff;
    public GameObject musicOn;
    public GameObject musicOff;
    public AudioSource myAudioSource;
    public AudioClip menuBackgroundMusic;
    public bool sfxon;
        public bool musicon;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource.clip=menuBackgroundMusic;
        myAudioSource.loop=true;
        myAudioSource.Play();

        musicon=PlayerPrefs.GetInt("music")==1;
        sfxon=PlayerPrefs.GetInt("sfx")==1;
        musicOn.SetActive(musicon);
        musicOff.SetActive(!musicon);
        sfxOn.SetActive(sfxon);
        sfxOff.SetActive(!sfxon);
        

    }

    // Update is called once per frame
    void Update()
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
           if(PlayerPrefs.GetInt("music")==1)
           {
               myAudioSource.volume=0.3f;
           }
           else
           {
               myAudioSource.volume=0f;
           }
        
    }

    public void onPlay ()
    {
        SceneManager.LoadScene("main game");
    }

    public void onExit ()
    {
        Application.Quit();
    }
    public void musicOpen ()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        PlayerPrefs.SetInt("music",1);


    }
      public void musicClose ()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        PlayerPrefs.SetInt("music",0);


    }
    public void sfxOpen ()
    {
sfxOn.SetActive(true);
        sfxOff.SetActive(false);
        PlayerPrefs.SetInt("sfx",1);

    }
     public void sfxClose ()
    {
sfxOn.SetActive(false);
        sfxOff.SetActive(true);
        PlayerPrefs.SetInt("sfx",0);

    }
}
