using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
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

    public Movement player;
    public DeathScript death;
    private bool protection;
    public GameObject particles;
    public CameraMovement cam;
    public GameObject tutorial;
    public ScoreManager timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<ScoreManager>();
        enemyRB2D = GetComponent<Rigidbody2D>();
        death = FindObjectOfType<DeathScript>();
        player = FindObjectOfType<Movement>();
        cam = FindObjectOfType<CameraMovement>();

    }


    private void FixedUpdate()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, edgeCheckRadius, whatIsEdge);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //el enemigo mata al jugador
        if (collision.gameObject.tag == "Player")
        { 

            if (protection == false)
            { 
                death.Death();
                timer.enabled = false;
            }
            if(protection == true)
            {
                Destroy(gameObject);
                cam.enemy = false;
                tutorial.SetActive(false);
                Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
            }
        }
        if(collision.gameObject.tag == "deathGround")
        {
            Destroy(gameObject);
        }    

    }

    // Update is called once per frame
    void Update()
    {

        protection = player.anim.GetBool("Protect");

        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        

        if (moveRight)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            enemyRB2D.velocity = new Vector2(moveSpeed, enemyRB2D.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
            enemyRB2D.velocity = new Vector2(-moveSpeed, enemyRB2D.velocity.y);
        }
    }
}
