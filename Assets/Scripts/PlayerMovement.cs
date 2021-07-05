using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public score score;


	public float runSpeed = 30f;
    public VariableJoystick variableJoystick;

	float horizontalMove = 0f;
	public bool jump = false;
	bool crouch = false;
	public Animator anim;
	public bool jumpPressed;
   

	void Start()
	{
		jumpPressed=false;
	}

	// Update is called once per frame
	void Update () {


anim.SetBool("land",controller.m_Grounded);

		horizontalMove =  variableJoystick.Horizontal * runSpeed;

	

		/*if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}*/

	} 
public void jumpEvent()
	{
			jump = true;
			anim.SetBool("jump",true);
			jumpPressed=true;

		}
	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
        //when player die
		if(transform.position.y <= Camera.main.transform.position.y - 5.8)
		{
			if(PlayerPrefs.GetInt("sfx")==1)
			{
			score.myAudioSource2.Play ();
			}
			Destroy(gameObject);
		}
	}

	public void OnLanding ()
	{
		anim.SetBool("jump", false);
	}

	
}
