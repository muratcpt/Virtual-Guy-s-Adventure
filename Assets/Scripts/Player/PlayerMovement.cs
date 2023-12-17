using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpAmount = 14f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState{idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2 (dirX * speed, rb2d.velocity.y);

        if(Input.GetKeyDown(KeyCode.W) && IsGrounded()) 
        {
            jumpSoundEffect.Play();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpAmount);

        }

        UpdateAnimationState();

    }
    
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb2d.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb2d.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public bool CanAttack()
    {
        return dirX == 0 && IsGrounded();
    }
}
