using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPlayer : MonoBehaviour
{
    //variables publicas
    public int dmgToGive;

    //deteccion de entrada de trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //llamar la funcion del health manager para bajarle vide al jugador
            HealthManager.DamagePlayer(dmgToGive);

            //referencia al control del jugador
            PlayerController player = collision.GetComponent<PlayerController>();
            //igualar el valor de knockback counter con la duracion del knockback
            player.knockbackCounter = player.knockbackLength;

            //checar si la posicion del jugador en x es menor a la posicion de x de este objeto
            if(collision.transform.position.x < transform.position.x)
            {
                //activamos booleano de knockback
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }
            ScoreManager.AddPoints(-50);

        }
    }
}
