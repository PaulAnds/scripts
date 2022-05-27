using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeObject : MonoBehaviour
{

    [SerializeField]
    private float timedLife = 2.0f;
    private float startTime = 0.0f;

    public PlayerMovement player;
    public int scene;

    private void OnEnable()
    {
        startTime = Time.time;
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >timedLife)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(player.gameObject);
            SceneManager.LoadScene(scene);
        }
    }
}
