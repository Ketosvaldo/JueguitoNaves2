using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SIU_CameraFollow : MonoBehaviour
{//START CLASS SIU_CameraFollow
    //Variables Privadas
    private Transform player; //REF COMP Transform del Jugador

    private float damping = 2f; //Valor para suavizar la interpolacion linear de camara
    private float height = 10f; //Altura de seguimiento de la camara

    private Vector3 startPosition; //Posicion inicial de camara

    private bool canFollow; //Camara puede seguir a jugador? Y/N

    private void Start()
    {//START Start
        //Esto pasa despues de que se genere el nivel
        //Valor inicial de la REF player
        //Buscar un objeto con el tag "Player" en la escena
        //ASIGNAR EL TAG PLAYER AL JUGADOR
        player = GameObject.FindWithTag("Player").transform;

        //Declarar posicion inicial de camara
        startPosition = transform.position;

        //La camara sigue al jugador
        canFollow = true;
    }//END Start

    private void Update()
    {//START Update
        //Llamar a la funcion de seguimiento de camara
        Follow();
    }//END Update

    //Funcion de seguimiento de camara
    //SE LLAMA EN UPDATE
    void Follow() 
    {//START Follow
        //Checar si la camara puede seguir al jugador
        if (canFollow) 
        {//START IF
            //Interpolacion lineal entre la posicion inicial de camar respecto a la pos de jugador
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + 10f,
                                                                              player.position.y + height,
                                                                              player.position.z - 10f), 
                                                                              Time.deltaTime * damping);
        }//END IF
    }//END Follow

    //Accesor CanFollow
    public bool CanFollow 
    {//START CanFollow
        get 
        {
            return canFollow;
        }

        set 
        {
            canFollow = value;
        }
    }//END CanFollow
}//END CLASS SIU_CameraFollow
