using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_Bullet : MonoBehaviour
{//START CLASS ER_Bullet
    //Variables Privadas
    [SerializeField]
    private Rigidbody RB; //REF COMP Rigidbody de la bala

    //Funcion para mover la bala
    public void MoveBullet(float _speed) 
    {//START MoveBullet
        //Adicion de velocidad como fuerza al RB de bala
        //La bala se impulsa hacia adelante
        RB.AddForce(transform.forward.normalized * _speed);

        //Invocar la funcion de destruccion de GOs despues de 5s
        Invoke("DestroyGOs", 5f);
    }//END MoveBullet

    //Funcion para destruir GameObjects
    void DestroyGOs() 
    {//START DestroyGOs
        //Destruir el objeto que tiene este script
        Destroy(gameObject);
    }//END DestroyGOs

    //Metodo para evaluar entradas a colisiones
    private void OnCollisionEnter(Collision _other)
    {//START OnCollisionEnter
        //Vamos a checar si el objeto entrante cuenta con un tag de Obstaculo
        if(_other.gameObject.tag == "Obstacle") 
        {//START IF
            //Llamar a la funcion de destruccion de GOs
            DestroyGOs();
        }//END IF
    }//END OnCollisionEnter
}//END CLASS ER_Bullet
