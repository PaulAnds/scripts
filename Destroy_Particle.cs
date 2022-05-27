using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Particle : MonoBehaviour
{//start of class
    //variables privadas
    private ParticleSystem thisParticleSystem; //referencia de sistema de particulas

    private void Start()
    {//start start
        //iniciar referencia
        thisParticleSystem = GetComponent<ParticleSystem>();
    }//end start

    private void Update()
    {//start update
        //checar que el sistema este activo
        if(thisParticleSystem.isPlaying)
        {//start of if
            //no haces nada. salimos de la funcion
            return;
        }//end of if

        //es cuando el sistema no se esta reproduciondo/este activa
        //destruir gameobject
        Destroy(gameObject);
    }//end update
}//end of class

