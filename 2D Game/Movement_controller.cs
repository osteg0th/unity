using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_controller : MonoBehaviour {
    Player_controller controller;
    Animator animator;
    float move=0;
    bool jump = false;
    bool crouch = false;
    public float speed = 10f;
	void Start ()
    {
        controller = GetComponent<Player_controller>();
        animator = GetComponent<Animator>();
	}

	void Update ()
    {
        move = Input.GetAxisRaw("Horizontal")*speed;
        animator.SetFloat("speed", Mathf.Abs(move));
        jump = Input.GetButton("Jump");
        if(jump)
        animator.SetBool("Jump", true);
        crouch = Input.GetButton("Crouch");
        //if(Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //}
        //else if(Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}
    }
    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("Crouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime, crouch, jump);
    }
}
