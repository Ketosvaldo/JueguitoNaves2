using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_GroundBlock : MonoBehaviour
{//START CLASS ER_GroundBlock
    //Variables Publicas
    [Header("Propiedades de Pieza de Terreno")]
    public Transform otherBlock; //Info de COM Transform de LA OTRA pieza de terreno
    public float halfLength = 100f; //Mitad de longitud de la pieza de terreno

    //Variables Privadas
    private Transform player; //REF COMP Transform de Jugador

    private float endOffset = 10f; //Valor para ayudar a "finalizar" una pieza de terreno

    private void Start()
    {//START Start
        //Dar valor a la REF player
        //Busqueda en escena del COMP Transform de un objeto con el tag de player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }//END Start

    private void Update()
    {//START Update
        //Llamar a la funcion que mueve la pieza de terreno
        MoveBlock();
    }//END Update

    //Funcion que mueve la pieza de terreno
    void MoveBlock() 
    {//START MoveBlock
        //Checar si la posicion actual en Z de la pieza de terreno mas su mitad es
        //menor a la posicion del jugador en Z menos una distancia
        if(transform.position.z + halfLength < player.transform.position.z - endOffset) 
        {//START IF
            //Si es el caso, el jugador sale de la pieza de terreno
            //Mover ESTA Pieza de terreno a una Nueva posicion al FINAL de LA OTRA pieza de terreno
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, otherBlock.position.z + halfLength * 2);
        }//END IF
    }//END MoveBlock
}//END CLASS ER_GroundBlock
