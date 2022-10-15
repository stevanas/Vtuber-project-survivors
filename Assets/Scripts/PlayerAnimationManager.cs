using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator anim;
    PlayerMover mover;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        mover = GetComponent<PlayerMover>();
    }
    private void Update()
    {
        //Debug.Log(mover.rb.velocity);
        anim.SetFloat("Horizontal", mover.move.x);
        anim.SetFloat("Vertical", mover.move.y);
    }
}
