using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    [SerializeField] protected float speed;
    [SerializeField] protected float pushPower;
    protected Rigidbody2D rb;
    protected float horizontal;
    protected bool isRightDirection = true;
    protected Collider2D boxColider2d;
    protected Animator anm;
    [SerializeField] protected LayerMask Ground;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        PlayerMove.instance = this;
        boxColider2d = this.GetComponent<Collider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        anm = this.GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        CheckInput();
        CheckDirection();
        UpdateAnimations();
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {
        Move();
    }
    private void CheckInput()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Move()
    {
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
    }
    public void Jump()
    {
        if (IsGrounded()) rb.velocity = new Vector2(rb.velocity.x, pushPower);
    }
    public void CheckDirection()
    {
        if (isRightDirection && horizontal < 0)
        {
            FlipDirection();
        }
        else if (!isRightDirection && horizontal > 0)
        {
            FlipDirection();
        }
    }
    protected void UpdateAnimations()
    {
        anm.SetBool("isWalking", horizontal != 0);
        anm.SetBool("isGround", IsGrounded());
    }
    protected void FlipDirection()
    {
        isRightDirection = !isRightDirection;
        transform.Rotate(0, 180, 0);
    }
    protected bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxColider2d.bounds.center, boxColider2d.bounds.size, 0, Vector2.down, 0.1f, Ground);
        return raycastHit2D.collider != null;
    }

}
