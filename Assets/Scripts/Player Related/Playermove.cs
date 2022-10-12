using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Playermove : MonoBehaviour {

    private int moveSpeed;
    private Rigidbody rig;

    private Vector3 moveInput;
    private Vector3 moveVel;
	// Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }
        else
        {
            moveSpeed = 5;
        }
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVel = moveInput * moveSpeed;

	}

    private void FixedUpdate()
    {
        rig.velocity = moveVel;
    }

}
