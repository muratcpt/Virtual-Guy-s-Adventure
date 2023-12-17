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
    private PLayerLife firetrigger;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        firetrigger = GetComponent<PLayerLife>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateF�reTrap());
            }
            if(active)
            {
                Debug.Log("Hasar ald�n");
            }
        }
    }
    private IEnumerator ActivateF�reTrap()
    {
        triggered = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.color = Color.white;
        active = true;
        anim.SetBool("activated", true);
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }

}
