using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody2D rb;
    Vector2 move;
    InputHandler input;

    private void Start()
    {
        input = InputHandler.instance;
    }

    private void Update()
    {
        move.x = input.xInput;
        move.y = input.yInput;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * walkSpeed * Time.fixedDeltaTime);
    }

}
