﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	public CharacterController2D controller;
	public Animator animator;


	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump=false;
	bool crouch=false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		
		animator.SetFloat("player_speed", Mathf.Abs(horizontalMove));

		if(Input.GetButtonDown("Jump"))
		{
			jump=true;
			animator.SetBool("player_is_jumping",true);
		}
		
		if(Input.GetButtonDown("Crouch"))
		{
			crouch=true;
		}else if(Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	
	
	
    }
	
	public void OnLanding(){
		animator.SetBool("player_is_jumping",false);
	}
	
	public void onCrouching( bool isCrouching)
	{
		animator.SetBool("player_is_crouching",isCrouching);
	}
	
	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
		
		
	}
}
