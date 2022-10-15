using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    //Inputs
    public float xInput;
    public float yInput;
    public bool shiftHeld;
    public bool leftClickHeld;
    public bool leftClickUp;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        shiftHeld = Input.GetKey(KeyCode.LeftShift);
        leftClickHeld = Input.GetMouseButton(0);
        leftClickUp = Input.GetMouseButtonUp(0);
    }
}
