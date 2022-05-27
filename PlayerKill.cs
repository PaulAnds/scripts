using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    public DeathScript death;
    public ScoreManager timer;

    private void Start()
    {
        death = FindObjectOfType<DeathScript>();
        timer = FindObjectOfType<ScoreManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            death.Death();
            Debug.Log("muerto");
            timer.enabled = false;
        }
    }
}
