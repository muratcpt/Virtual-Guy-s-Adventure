using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal2 : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "MainChar")
        {
            anim.SetBool("isTrigger", true);
            Invoke("Portal", 1f);


        }

    }

    private void Portal()
    {
        SceneManager.LoadScene(3);
    }

}