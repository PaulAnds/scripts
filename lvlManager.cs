using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlManager : MonoBehaviour
{
    public GameObject currentCheckpoint; //referencia de go de el checkpoint
    public GameObject deathParticle;
    public GameObject respawnParticle;

    public int penaltyOfPoints;

    private PlayerController player; //referencia al script de playercontroller
    private HealthManager healthmanager;//referencia al script de healthmanager
    ScoreManager ScoreManager;
    public float RespawnDelay = 1.0f;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthmanager = FindObjectOfType<HealthManager>();
    }

    //esto respaunea el jugador
    public void RespawnPlayer()
    {
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        player.GetComponent<BoxCollider2D>().enabled = false;
        //Llamar a la cortina de la reaparicion
        StartCoroutine("RespawnPlayerCo");
    }

    //corrutina de aparicion
    public IEnumerator RespawnPlayerCo()
    {
        //instanciar cuando el jugador muera
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        //bajar puntos cuando muera el jugador
        ScoreManager.AddPoints(-penaltyOfPoints);

        //Desactivar control de jugador
        player.enabled = false;
        //desaparecer el modelo
        player.GetComponent<Renderer>().enabled = false;

        Debug.Log("Player respawned");//aqui revive

        //pausa de reaparicion/cumplir con corountine
        yield return new WaitForSeconds(RespawnDelay);
        //mover al player en su ultimo checkpoint
        player.transform.position = currentCheckpoint.transform.position;

        //reseteo del contador de knockback del jugador
        player.knockbackCounter = 0;

        //activar control del jugador/ vicibilidad del jugador
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;

        healthmanager.fullHealth();
        healthmanager.playerIsDead = false;

        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        //instanciar cuando el jugador reviva en el checkpoint
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

}
