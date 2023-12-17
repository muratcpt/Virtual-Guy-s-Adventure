using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{

    [Header("Firetrap Timers")]
    private float activationDelay = 2f;
    private float activeTime = 2f;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {

            }
            if(active)
            {
                
            }
        }
    }

}
