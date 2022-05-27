using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public
    public float moveSpeed;
    public float jumpPower;

    [Header("Deteccion de tierra")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //private
    private bool grounded;
    private Rigidbody2D RB2D2;
    public Animator anim; //componente de aninmator de jugador

    //chocolate
    public int chocolate;
    public Pause_menu pause;


    void Start()
    {
        RB2D2 = GetComponent<Rigidbody2D>();//el rigidbody que se le pone al script
        anim = GetComponent<Animator>();
        pause = FindObjectOfType<Pause_menu>();
        chocolate = 0;
    }

    void FixedUpdate()
    {             //crea un circulo      posicion de circle     tamano de circle      si es que toca este layer = true
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Protect", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "chocolate")
        {
            chocolate += 1;
        }
    }
    private void Update()
    {

        //cuando toca el piso y presione espacio puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, jumpPower);
        }

        //animacion de salto
        anim.SetBool("Ground", grounded);



        //movimiento a la derecha
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RB2D2.velocity = new Vector2(moveSpeed, RB2D2.velocity.y);
        }
        //movimiento a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RB2D2.velocity = new Vector2(-moveSpeed, RB2D2.velocity.y);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Protect", true);
            RB2D2.velocity = new Vector2(-moveSpeed/2, RB2D2.velocity.y);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Protect", true);
            RB2D2.velocity = new Vector2(moveSpeed / 2, RB2D2.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Protect", true);
        }
        

        //amimacion para caminar
        anim.SetFloat("Speed", Mathf.Abs(RB2D2.velocity.x));

        //voltear al jugador
        if (RB2D2.velocity.x > 0f)
        {
            //escala normal
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else if (RB2D2.velocity.x < 0f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }

    }
}
