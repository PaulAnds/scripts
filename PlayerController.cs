using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public
    public float moveSpeed;
    public float jumpPower;

    [Header("Disparos")]
    public Transform bulletPoint;
    public GameObject bullet;
    public float shotDelay;//retraso de disparo

    [Header("Deteccion de tierra")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    [Header("KnockBack")]
    public float knockbackDistance;//distancia en la que el jugador es empujado
    public float knockbackLength;//duracion del empuje
    public float knockbackCounter;//conteo para desactivar knockback
    public bool knockFromRight;//detector para saber si el jugador ese empujado a der o izq


    //private
    private bool grounded;
    private Rigidbody2D RB2D2;
    private bool doubleJump;
    private Animator anim; //componente de aninmator de jugador
    private float moveVelocity; //variable para guardar velocidad del player
    private float shotDelayCounter;//contador del retraso de bala

    void Start()
    {
        RB2D2 = GetComponent<Rigidbody2D>();//el rigidbody que se le pone al script
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {             //crea un circulo      posicion de circle     tamano de circle      si es que toca este layer = true
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    private void Update()
    {

        if(grounded)//cuando en el piso double jump es falso
        {
            doubleJump = false;
        }
        //cuando toca el piso y presione espacio puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, jumpPower);               
        }
        //si double es falso y no esta en el piso puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJump)
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, jumpPower);
            doubleJump = true;//no deja que se pueda saltar otra vez
        }

        //animacion de salto
        anim.SetBool("Grounded", grounded);

        //valor inicial de velocidiad
        //cambiar el valor dependiendo del imput del movimiento
        moveVelocity = 0f;

        //movimiento a la derecha
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            //RB2D2.velocity = new Vector2(moveSpeed, RB2D2.velocity.y);

            //valor de movevelocity cuando el jugador va a la derecha
            moveVelocity = moveSpeed;
        }
        //movimiento a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //RB2D2.velocity = new Vector2(-moveSpeed, RB2D2.velocity.y);

            //valor de movevelocity cuando el jugador va a la izquierda
            moveVelocity = -moveSpeed;
        }

        //nueva velocidad RB del jugador
        //RB2D2.velocity = new Vector2(moveVelocity, RB2D2.velocity.y);

        //el movimiento normal se ara cuando el contador del knockback es 0
        if (knockbackCounter <= 0)
        {//start in if
            //movimiento normal
            //nueva velocidad RB del jugador
            RB2D2.velocity = new Vector2(moveVelocity, RB2D2.velocity.y);
        }//end  in if
        else
        {
            //si el empuje viene desde la derecha 
            if(knockFromRight)
            {
                //velocidad de RB2D cuando el jugador es empujado desde la derecha
                RB2D2.velocity = new Vector2(-knockbackDistance, knockbackDistance);
            }
            //si el empuje viene desde la izquierda
            if (!knockFromRight)
            {
                //velocidad de RB2D cuando el jugador es empujado desde la izquierda
                RB2D2.velocity = new Vector2(knockbackDistance, knockbackDistance);
            }
            //restar el contador de knockback usando el tiempo
            knockbackCounter -= Time.deltaTime;
        }



        //amimacion para caminar
       anim.SetFloat("Speed", Mathf.Abs(RB2D2.velocity.x));

        //voltear al jugador
        if(RB2D2.velocity.x > 0f)
        {
            //escala normal
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (RB2D2.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);

            //inicializar el conteo de retraso para disparar
            shotDelayCounter = shotDelay;
        }

        //input para mantener disparos
        //aplicar delay de disparos
        if(Input.GetKey(KeyCode.E))//disparo mantenido
        {
            //resta el contador de disparos para maximisar lo que puedas disparar
            shotDelayCounter -= Time.deltaTime;
            //checar que se acabo el contador de retraso
            if(shotDelayCounter <= 0)
            {//cuando ya llegue a 0 ya se puede disparar
                shotDelayCounter = shotDelay;
                //instaciar el proyectil
                Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
            }
        }
        
    }

}
