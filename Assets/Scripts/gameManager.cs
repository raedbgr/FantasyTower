using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject pause_backGround;
    public GameObject fail_backGround;
    public GameObject jumpB;
    public GameObject joystick;
    public GameObject pauseB;

    // Start is called before the first frame update
    void Start()
    {
        pause_backGround.SetActive(false);
        fail_backGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // pause menu opening
    public void OnPause()
    {
        Time.timeScale = 0f;
        pause_backGround.SetActive(true);
        jumpB.SetActive(false);
        joystick.SetActive(false);
        pauseB.SetActive(false);

    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        pause_backGround.SetActive(false);
        jumpB.SetActive(true);
        joystick.SetActive(true);
        pauseB.SetActive(true);

    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");

    }

    public void OnLose()
    {
        fail_backGround.SetActive(true);
        jumpB.SetActive(false);
        joystick.SetActive(false);
        pauseB.SetActive(false);

    }
}
