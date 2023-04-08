using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByButtons : PlayerMove
{
    public static PlayerMoveByButtons instance_;
    protected override void Awake()
    {
        PlayerMoveByButtons.instance_ = this;
        boxColider2d = this.GetComponent<Collider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        anm = this.GetComponent<Animator>();
    }
    protected override void Update()
    {
        CheckDirection();
        UpdateAnimations();
    }
    public void SetHorizontal(float value)
    {
        horizontal = value;
    }
    
}
