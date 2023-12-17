using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharCam : MonoBehaviour
{
    [SerializeField] private Transform MainChar;
    private void Update()
    {
        transform.position = new Vector3(MainChar.position.x, MainChar.position.y, transform.position.z);
    }
}
