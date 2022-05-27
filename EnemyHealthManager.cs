using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    //variables publicas
    public int health;//cantidad de vida del enemigo
    public GameObject enemydeathEF; //referencia de particulas de muerte
    public int pointsforKills;//los puntos que ganas por matar al enemigo

    //variables privadas


    private void Update()
    {
        if(health <= 0)
        {
            //instanciar particulas de muerte
            Instantiate(enemydeathEF, transform.position, transform.rotation);

            //agregar puntos con el score manager
            ScoreManager.AddPoints(pointsforKills);

            //mata al enemigo
            Destroy(gameObject);
        }
    }
    
    //funcion para danar al enemigo
    public void DmgEnemy(int _dmgToGive)
    {
        health -= _dmgToGive;
    }




}
