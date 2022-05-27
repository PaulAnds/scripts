using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    public lvlManager lvlManager;


    private void Start()
    {
        lvlManager = FindObjectOfType<lvlManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            lvlManager.currentCheckpoint = gameObject;
        }

        Debug.Log("Checkpoint Activated: " + transform.position);
    }

}
