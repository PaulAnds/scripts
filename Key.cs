using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject prefabJump;
    public GameObject prefabGoggles;
    public GameObject spawn;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        spawn = GameObject.Find("Spawner");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.mod == 2)
            {
                Instantiate(prefabJump, spawn.transform.position, spawn.transform.rotation);
                if (spawn.transform.position.x == -.3f)
                {
                    spawn.transform.position = new Vector3(.3f, 0, 0);
                }
                if (spawn.transform.position.x == .3f)
                {
                    spawn.transform.position = new Vector3(-.3f, 0, 0);
                }
            }
            if (player.mod == 3)
            {
                Instantiate(prefabGoggles, spawn.transform.position, spawn.transform.rotation);
                if (spawn.transform.position.x == -.3f)
                {
                    spawn.transform.position = new Vector3(.3f, 0, 0);
                }
                if (spawn.transform.position.x == .3f)
                {
                    spawn.transform.position = new Vector3(-.3f, 0, 0);
                }
            }

            Destroy(gameObject);
            player.mod = 1;
        }
    }
}
