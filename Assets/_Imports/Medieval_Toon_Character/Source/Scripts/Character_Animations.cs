using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Animations : MonoBehaviour {
	private Animator animator;
	private float verticalInput, horizontalInput, run, rotateSpeed;
    private bool isRotating = false;

	void Start () {
		animator = GetComponent <Animator> ();
	}
	
	void Update () {
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space")) {
            animator.SetBool("Jump", true);
        }
		Sprinting();
        AddTurningSpeed(verticalInput, horizontalInput);
        Turning(horizontalInput);
	}

	void FixedUpdate (){
		animator.SetFloat("Walk",verticalInput + rotateSpeed);
		animator.SetFloat("Run",run);
		animator.SetFloat("Turn",horizontalInput);
		animator.SetBool("IsRotating", isRotating);
	}
    
    void Turning(float horizontalInput) {
        if (horizontalInput != 0) {
            isRotating = true;
        } else {
            isRotating = false;
        }
    }

    void AddTurningSpeed(float verticalInput, float horizontalInput) {
        if(verticalInput == 0 && horizontalInput != 0) {
            rotateSpeed = 1f;
        } else {
            rotateSpeed = 0f;
        }
    }

	void Sprinting(){
		if (Input.GetKey(KeyCode.LeftShift))
			run=0.2f;
		else
			run=0.0f;
	}
}