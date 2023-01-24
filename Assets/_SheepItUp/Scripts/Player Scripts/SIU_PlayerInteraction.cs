using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIU_PlayerInteraction : MonoBehaviour
{//START CLASS SIU_PlayerInteraction
    //Variables Privadas
    private Rigidbody RB; //REF COMP Rigidbody del jugador

    private bool playerDied; //El jugador murio? Y/N

    private SIU_CameraFollow cameraFollow; //REF SCRIPT SIU_CameraFollow

    private void Awake()
    {//START Awake
        //Dar valor inicial a la REF RB
        //Busqueda de componentes en el objeto que tiene este script
        RB = GetComponent<Rigidbody>();

        //Inicializar REF cameraFollow
        //Busqueda de componentes dentro de la camara principal del juego
        cameraFollow = Camera.main.GetComponent<SIU_CameraFollow>();
    }//END Awake

    private void Update()
    {//START Update
        //Checar si el jugador esta vivo
        if (!playerDied) 
        {//START IF 
         //Vamos a checar si la velocidad del RB del jugador cuenta con una magnitud alta
            if (RB.velocity.sqrMagnitude > 60)
            {//START IF 2
                //Esto significa que el jugador esta cayendo 
                //El jugador esta muerto
                playerDied = true;

                //La camara deja de seguir al jugador
                cameraFollow.CanFollow = false;

                //Sonido de fin de juego
                SIU_SoundManager.instance.GameEndSound();

                //Reiniciar el juego
                SIU_GameplayController.instance.RestartGame();
            }//END IF 2
        }//END IF
    }//END Update

    //Funcion que evalua entradas a un trigger
    private void OnTriggerEnter(Collider _other)
    {//START OntriggerEnter
        //Interaccion con GO que tienen trigger

        //MONEDA
        //Checar si el objeto entrante tiene el tag de coin
        if(_other.tag == "Coin") 
        {//START IF
            //Entramos al trigger de moneda
            //Sonido de colectible
            SIU_SoundManager.instance.PickupCoin();

            //Subir score
            SIU_GameplayController.instance.AddScore();

            //Destruir el objeto entrante
            Destroy(_other.gameObject);
        }//END IF

        //PICOS
        //Checar si el objeto entrante tiene el tag de Spike
        //CREAR TAG Spike EN EDITOR
        if(_other.tag == "Spike") 
        {//START IF
            //Entramos al trigger de picos

            //Camara deja de seguir al jugador
            cameraFollow.CanFollow = false;

            //Sonido de fin de juego
            SIU_SoundManager.instance.GameEndSound();

            //Reiniciar el juego
            SIU_GameplayController.instance.RestartGame();

            //Destruir GO de Jugador
            Destroy(gameObject);
        }//END IF
    }//END OnTriggerEnter

    //Funcion para evaluar entrada a colisiones
    private void OnCollisionEnter(Collision _other)
    {//START OnCollisionEnter
        //Checar si el player colisiona con la plataforma final
        if(_other.gameObject.tag == "EndPlatform") 
        {//START IF
            //GANAMOS!
            //Sonido de victoria
            SIU_SoundManager.instance.GameStartSound();

            //Reiniciar el juego
            //ESTO VA CAMBIAR EN EL PARCIAL
            SIU_GameplayController.instance.PutoPendejo();
        }//END IF
    }//END OnCollisionEnter
}//END CLASS SIU_PlayerInteraction
