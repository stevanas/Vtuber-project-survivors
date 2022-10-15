using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;
    
    public float horizontal;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        animator.SetFloat("Horizontal", horizontal);
     }
}