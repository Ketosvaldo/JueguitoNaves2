using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_GameplayController : MonoBehaviour
{//START CLASS ER_GameplayController
    //Variables Publicas
    public static ER_GameplayController instance; //Variable Singleton

    [Header("Arreglos de Objetos")]
    public GameObject[] obstaclePrefabs; //Arreglo de GOs para obstaculos
    public GameObject[] zombiePrefabs; //Arreglo de GOs para zombies

    [Header("Carriles de Objetos")]
    public Transform[] lanes; //Arreglo de carriles para generar objetos

    [Header("Tiempos para generar Obstaculos")]
    public float minObstacleDelay = 10f; //Tiempo minimo para generar obstaculos
    public float maxObstacleDelay = 40f; //Tiempo maximo para generar obstaculos

    //Variables Privadas
    private float halfGroundSize; //Mitad de longitud de terreno

    private ER_BaseController baseController; //REF SCRIPT ER_BaseController

    private void Awake()
    {//START Awake
        //Llamada al metodo que crea el Singleton
        MakeSingleton();
    }//END Awake

    private void Start()
    {//START Start
        //Inicializar referencias
        //Valor a la variable halfGroundSize por medio de una busqueda de una variable dentro del script ER_GroundBlock
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<ER_GroundBlock>().halfLength;

        //Valor de la referencia baseController
        //Busqueda en escena de un objeto con el tag Player para encontrar el componente ER_BaseController
        baseController = GameObject.FindGameObjectWithTag("Player").GetComponent<ER_BaseController>();

        //Iniciar la corrutina para generar obstaculos
        StartCoroutine(GenerateObstaclesCo());
    }//END Start

    //Metodo para crear singleton
    void MakeSingleton() 
    {//START MakeSingleton
        //Checar si no existe una referencia de la instancia
        if(instance == null) 
        {//START IF
            //Si es el caso, esta clase se vuelve la instancia
            instance = this;
        }//END IF
        //Checar si existe una instancia 
        else if(instance != null) 
        {//START ELSE IF
            //Si es el caso, destruir el objeto que tenga esta clase
            Destroy(gameObject);
        }//END ELSE IF
    }//END MakeSingleton

    //Corrutina para generar obstaculos
    IEnumerator GenerateObstaclesCo()
    {//START GenerateObstaclesCo
        //Temporizador local aleatorio basado en la velocidad del jugador
        float _timer = Random.Range(minObstacleDelay, maxObstacleDelay) / baseController.speed.z;

        //Pausa que emplea el temporizador local
        //Esta linea completa la corrutina
        yield return new WaitForSeconds(_timer);

        //------------GENERACION DE OBSTACULOS--------------------
        //Llamar a la funcion para crear obstaculos
        //VUELVE AQUI!

        //Iniciar la corrutina para generar obstaculos
        //Creacion continua de obstaculos despues de iniciar el juego
        StartCoroutine(GenerateObstaclesCo());
    }//END GenerateObstaclesCo

    //Metodo para generar obstaculos
    void CreateObstacles(float _zPos)
    {//START CreateObstacles

    }//END CreateObstacles
}//END CLASS ER_GameplayController
