using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    //Inputs
    public float xInput;
    public float yInput;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        xInput = Input.GetAxisRaw("Hotrizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
}
