using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    public RuntimeAnimatorController animkey;
    public RuntimeAnimatorController animjump;
    public RuntimeAnimatorController animgoggles;
    public RuntimeAnimatorController animnun;

    //mods
    public int mod;
    public GameObject glassoff;


    void Start()
    {
        RB2D2 = GetComponent<Rigidbody2D>();//el rigidbody que se le pone al script
        anim = GetComponent<Animator>();
        mod = 0;
    }

    void FixedUpdate()
    {             //crea un circulo      posicion de circle     tamano de circle      si es que toca este layer = true
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    
    private void Update()
    {

        //cuando toca el piso y presione espacio puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, jumpPower);
        }

        //animacion de salto
       anim.SetBool("Grounded", grounded);



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


        //mods
        if(mod == 0)
        {
            jumpPower = 5;
            //no mods available
            Debug.Log("mod = 0");
            glassoff.SetActive(true);
            anim.runtimeAnimatorController = animnun;
        }
        else if(mod == 1)
        {
            jumpPower = 5;
            //change sprite with key
            Debug.Log("mod = 1");
            glassoff.SetActive(true);
            anim.runtimeAnimatorController = animkey;
        }
        else if(mod == 2)
        {
            jumpPower = 7;
            //change sprite with jumpboost
            Debug.Log("mod = 2");
            glassoff.SetActive(true);
            anim.runtimeAnimatorController = animjump;
        }
        else if(mod == 3)
        {
            jumpPower = 5;
            glassoff.SetActive(false);
            //change sprite with goggles
            Debug.Log("mod = 3");
            anim.runtimeAnimatorController = animgoggles;
        }
        else
        {
            mod = 0;
        }



    }
}
