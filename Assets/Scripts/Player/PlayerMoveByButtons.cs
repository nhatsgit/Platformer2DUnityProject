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
        OnWalkSound();
    }
    
    public void SetHorizontal(float value)
    {
        horizontal = value;
    }
    public void StatusChange(bool isMobileMode)
    {
        this.GetComponent<PlayerMoveByButtons>().enabled = isMobileMode;
        isRightDirection = (this.transform.rotation.y == 0);
    }
    private void OnEnable()
    {
        isRightDirection = true;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
