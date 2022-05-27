using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{

    public GameObject deathNotice;
    public Movement player;
    public CameraMovement cam;
    public ParticleSystem deathParticles;

    private void Start()
    { 
        deathNotice.SetActive(false);
        Time.timeScale = 1f;
        player.gameObject.SetActive(true);
        player = FindObjectOfType<Movement>();
        cam = FindObjectOfType<CameraMovement>();
    }
    public void Death()
    {
        deathNotice.SetActive(true);
        Time.timeScale = .1f;
        cam.enabled = false;
        player.gameObject.SetActive(false);
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);
    }
}
