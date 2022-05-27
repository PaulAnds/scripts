using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    [Header("Deteccion de Paredes")]
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;

    [Header("Deteccion de Edges")]
    public Transform edgeCheck; //punto para detectar edges
    public float edgeCheckRadius;//radio circulo para detectar edge
    public LayerMask whatIsEdge;//el layer que se va a considerar como el edge

    private Rigidbody2D enemyRB2D;
    private bool hittingWall;
    private bool notAtEdge;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, edgeCheckRadius, whatIsEdge);
    }


    // Update is called once per frame
    void Update()
    {
        if(hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }



        if(moveRight)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
            enemyRB2D.velocity = new Vector2(moveSpeed, enemyRB2D.velocity.y);

        }
        else
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            enemyRB2D.velocity = new Vector2(-moveSpeed, enemyRB2D.velocity.y);
        }
    }
}
