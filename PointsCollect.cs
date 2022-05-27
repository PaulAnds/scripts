using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollect : MonoBehaviour
{
    public int points;

    ScoreManager ScoreManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            return;
        }
        ScoreManager.AddPoints(points);
        Destroy(gameObject);
    }
}
