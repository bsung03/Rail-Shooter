using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController character_Controller;
    private Vector3 move_Direction;
    public float speed = 5f;
    private float gravity = 20f;
    public float jump_Force = 10f;
    private float vertical_Velocity;


    void Start(){
        character_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        applyGravity();

        character_Controller.Move(move_Direction);
    }

    void applyGravity(){
        vertical_Velocity -= gravity * Time.deltaTime;
        Jump();
        move_Direction.y = vertical_Velocity * Time.deltaTime;
    }

    private void Jump()
    {
        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)){
            vertical_Velocity = jump_Force;
        }
    }
}
