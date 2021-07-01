using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 30f;

	float horizontalMove = 0f;
	public bool jump = false;
	bool crouch = false;
	public Animator anim;

	// Update is called once per frame
	void Update () {


anim.SetBool("land",controller.m_Grounded);

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("jump",true);
		}

		/*if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}*/

	} 

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

		if(transform.position.y <= Camera.main.transform.position.y - 5.7)
		{
			Destroy(gameObject);
		}
	}

	public void OnLanding ()
	{
		anim.SetBool("jump", false);
	}

	
}
