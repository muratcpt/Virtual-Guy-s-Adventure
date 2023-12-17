using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private float speed = 3f;
    
    private SpriteRenderer sprites;
    private Animator anim;
    private enum MovementStates { idle_down, walk_down, walk_side, walk_up }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprites = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, dirY * speed);
        UpdateAnimationState();

    }
    

    private void UpdateAnimationState()
    {
        MovementStates states;

        if (dirX > 0f)
        {
            states = MovementStates.walk_side;
            sprites.flipX = true;

        }
        else if (dirX < 0f)
        {
            states = MovementStates.walk_side;
            sprites.flipX = false;

        }
        else
        {
            states = MovementStates.idle_down;
        }
        if (dirY > 0f)
        {
            states = MovementStates.walk_up;
        }
        else if (dirY < 0f)
        {
            states = MovementStates.walk_down;
        }


        anim.SetInteger("states", (int)states);
    }




}
