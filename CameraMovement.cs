using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float max;
    public float rate;
    public float speed = 0;
    public bool enemy;
    public ScoreManager timer;
    public Pause_menu pause;

    private void Start()
    {
        rate = .1f;
        max = 1f;
        enemy = FindObjectOfType<Enemy_Movement>();
        timer = FindObjectOfType<ScoreManager>();
        pause = FindObjectOfType<Pause_menu>();
    }
    void Update()
    {
        if (pause.GameIsPaused == false)
        {
            if (rate < max && enemy == false)
            {
                rate = rate + 0.00001f;
                speed = (speed + 0.1f) * (rate / 60);
                timer.enabled = true;
            }

            Vector3 pos = new Vector3(0, transform.position.y + speed, -10);
            transform.position = pos;
        }
    }
}