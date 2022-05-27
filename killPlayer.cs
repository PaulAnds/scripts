using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public lvlManager lvlManager;

    private void Start()
    {   //busca el objeto quqe tiene el script de lvlmanager
        lvlManager = FindObjectOfType<lvlManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cuando el player toca el objeto pasa esto
        if(collision.tag == "Player")
        {
            lvlManager.RespawnPlayer();
            ScoreManager.AddPoints(-50);
        }
    }
    

}
