using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller : MonoBehaviour
{
    public float bulletSpeed;// que tan rapido va la bala
    public GameObject bulletdeath;
    public float rotationSpeed;//vel de rotacion del bullet
    public PlayerController player; //referencia al script de playercontoller
    public int dmg;//damage done to enemy

    private Rigidbody2D bulletRB; //referencia al rigidbody de la bala

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();// agarrar el rigidbody del bulletrb
        player = FindObjectOfType<PlayerController>();// encontrar el script en escena

        //checar si la escala local en x del jugador es menor de 0
        if(player.transform.localScale.x < 0)
        {
            //cambiar  el valor de speed, si el jugador voltea a la izquierda
            bulletSpeed = -bulletSpeed;
            //la rotacion del bullet cambia a la izquierda
            rotationSpeed = -rotationSpeed;
        }
        
            
    }

    private void Update()
    {
        bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);

        //utilizar el rotation speed como velocidad angular del proyectil
        bulletRB.angularVelocity = rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {//chcar si el objeto choca con el enemigo
        if(other.tag == "Enemy")
        {
            //llamar a la funcion enemy para restar la vida
            //para danar al enemigo
            other.GetComponent<EnemyHealthManager>().DmgEnemy(dmg);

        }
        Instantiate(bulletdeath, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
