using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public Transform FollowObject;
    //void Update()
    //{
    //    Vector3 pos = new Vector3(FollowObject.position.x + 1, transform.position.y, transform.position.z);
    //    transform.position = pos;
    //}

    public bool isFollowing;
    public float xOffset, yOffset;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        isFollowing = true;
    }
    void Update()
    {
        if(isFollowing)
        {
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
        }
    }
}