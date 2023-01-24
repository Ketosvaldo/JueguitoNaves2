using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Extension de DOTWeen

public class SIU_PlayerMovement : MonoBehaviour
{//START CLASS SIU_PlayerMovement
    //Variables Privadas
    private Rigidbody RB; //REF COMP Rigidbody del Jugador

    private float movementForce = 0.5f; //Fuerza de impulso de movimiento
    private float jumpForce = 0.15f; //Valor de salto
    private float jumpTime = 0.15f; //Tiempo de salto

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
    }

    void GetInput() 
    {
        if(Input.GetKeyDown(KeyCode.A) ||
           Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            Jump(true);
        }
        else if(Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.RightArrow)) 
        {//START ELSE IF
            //Llamar a la funcion de salto
            //El parametro sera false para saltar derecha
            Jump(false);
        }//END ELSE IF
    }//END GetInput

    //Funcion para saltar
    void Jump(bool _left) 
    {//START Jump
        //Llamada al sonido de salto
        SIU_SoundManager.instance.JumpSound();

        //Checar si el parametro de funcion es true
        if (_left)
        {//START IF
            //Brincar a la izquierda

            //Rotar al jugador usando DOTween
            //Rotamos hacia un vector sin duracion
            //Rotar antes de saltar
            transform.DORotate(new Vector3(0f, 90f, 0f), 0f);

            //Brincar usando DOTween y RB
            RB.DOJump(new Vector3(transform.position.x - movementForce,
                                  transform.position.y + jumpForce,
                                  transform.position.z), 0.5f, 1, jumpTime);
        }//END IF
        //El parametro es falso
        else 
        {//START ELSE
            //Brincar a la derecha

            //Rotar al jugador usando DOTween
            //Rotamos hacia un vector sin duracion
            //Rotar antes de saltar
            transform.DORotate(new Vector3(0f, -180f, 0f), 0f);

            //Brincar usando DOTween y RB
            RB.DOJump(new Vector3(transform.position.x,
                                  transform.position.y + jumpForce,
                                  transform.position.z + movementForce), 0.5f, 1, jumpTime);
        }//END ELSE
    }//END Jump
}//END CLASS SIU_PlayerMovement
