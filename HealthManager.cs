using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health;
    private Text healthtext;
    public int maxHealth;
    public bool playerIsDead;
    private lvlManager _lvlManager;

    private void Start()
    {
        healthtext = GetComponent<Text>();
        _lvlManager = FindObjectOfType<lvlManager>();
        health = maxHealth;
        playerIsDead = false;
        
    }

    private void Update()
    {
        if(health <= 0 && !playerIsDead)
        {
            //la vida del jugador es 0
            //evitar valores negativos
            health = 0;

            //llamar la funcion de reapparecer
            playerIsDead = true;
            _lvlManager.RespawnPlayer();
        }
        //actualizar la UI
        healthtext.text = "" + health;
    }

    //funcion para bajar los puntos de vida
    public static void DamagePlayer(int dmgToGive)
    {
        health -= dmgToGive;
    }

    //funcion que llena la vida del jugador
    public void fullHealth()
    {
        health = maxHealth;
    }
}
