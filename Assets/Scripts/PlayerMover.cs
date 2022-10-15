using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //stevanas#1997 is my discord for easier communication

    public float walkSpeed;
    public float sprintSpeed;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Vector2 move;
    InputHandler input;
    float curSpeed;
    [HideInInspector] public Camera cam;
    public enum movementState
    {
        walking,
        sprinting
    }
    movementState curState;

    private void Start()
    {
        input = InputHandler.instance;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        move.x = input.xInput;
        move.y = input.yInput;
        if(input.shiftHeld)
        {
            curState = movementState.sprinting;
            curSpeed = sprintSpeed;
        }
        else
        {
            curState = movementState.walking;
            curSpeed = walkSpeed;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move.normalized * curSpeed * Time.fixedDeltaTime);
    }

}
