using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish1 : MonoBehaviour
{
    private AudioSource finishSound;
    private bool LevelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player" && !LevelCompleted)
        {
            finishSound.Play();
            LevelCompleted = true;
            Invoke("CompleteLevel", 2f);

        }

    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(0);
    }

}
