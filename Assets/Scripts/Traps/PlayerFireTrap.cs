using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireTrap : MonoBehaviour
{
    private PLayerLife playerLife;
    private void Awake()
    {
        playerLife = GetComponent<PLayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Firetrap")
        {
            Debug.Log("Hasar aldýn");
        }
    }

}
