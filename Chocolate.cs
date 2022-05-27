using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chocolate : MonoBehaviour
{

    public Movement player;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            if(player.moveSpeed < 2)
            {
                player.moveSpeed = player.moveSpeed + 0.1f;
            }
            
            
        }
    }

}
