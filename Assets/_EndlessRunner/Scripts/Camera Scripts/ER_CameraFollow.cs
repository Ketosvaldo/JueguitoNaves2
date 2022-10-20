using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_CameraFollow : MonoBehaviour
{//START CLASS ER_CameraFollow
    //Variables Publicas
    [Header("Propiedades de Cámara")]
    public Transform target; //Objetivo de la camara
    public float distance = 6.5f; //Distancia en eje z entre la camara y su objetivo
    public float height = 3.5f; //Altura de la camara con respecto al objetivo

    public float heightDamping = 3.25f; //Valor para suavizar la interpolacion linear de altura
    public float rotationDamping = 0.27f; //Valor para suavizar la interpolacion linear de rotacion

    private void Start()
    {//START Start
        //Inicializar objetivo de camara 
        //Buscar en la escena un objeto con el tag de Player y usaremos su Transform
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }//END Start

    private void LateUpdate()
    {//START LateUpdate
        //Llamar a la funcion de seguimiento al objetivo
        FollowPlayer();
    }//END LateUpdate

    //Funcion de seguimiento al objetivo
    void FollowPlayer()
    {//START FollowPlayer
        //Declarar angulos de rotacion locales de Objetivo
        float _wantedRotationAngle = target.eulerAngles.y;

        //Declarar altura local de objetivo
        //Aqui se toma la posicion del jugador en Y y le sumamos el valor de height
        float _wantedHeight = target.position.y + height;

        //Declarar angulos de rotacion locales de Camara
        float _currentRotationAngle = transform.eulerAngles.y;

        //Declarar altura local de Camara
        float _currentHeight = transform.position.y;

        //Angulo de rotacion
        //Valor de angulo de rotacion de camara usando una interpolacion lineal con angulos y usamos el damping para suavizarla
        _currentRotationAngle = Mathf.LerpAngle(_currentRotationAngle, _wantedRotationAngle, rotationDamping * Time.deltaTime);

        //Altura
        //Valor de altura camara usando una interpolacion lineal y usamos el damping para suavizarla
        _currentHeight = Mathf.Lerp(_currentHeight, _wantedHeight, heightDamping * Time.deltaTime);

        //Angulos de rotacion aplicados a la rotacion
        //Valor de rotacion local
        Quaternion _currentRotation = Quaternion.Euler(0f, _currentRotationAngle, 0f);

        //Declarar posicion inicial de camara
        //Esta estara en la posicion del objetivo
        transform.position = target.position;

        //Distancia entre camara y objetivo
        transform.position -= _currentRotation * Vector3.forward * distance;

        //Altura de camara
        transform.position = new Vector3(transform.position.x, _currentHeight, transform.position.z);
    }//END FollowPlayer
}//END CLASS ER_CameraFollow
