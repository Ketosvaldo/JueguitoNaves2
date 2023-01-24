using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Extension para usar UI

public class SIU_GameplayController : MonoBehaviour
{//START CLASS SIU_GameplayController
    //Variables Publicas
    public static SIU_GameplayController instance; //Variable singleton de esta clase

    //Variables Privadas
    [SerializeField]
    private Text scoreText; //REF COMP Text que tiene el puntaje

    public GameObject winScreen;

    private int score; //Variable de puntaje

    private void Awake()
    {//START Awake
        //Referencia singleton
        if (instance == null)
            instance = this;
    }//END Awake

    //Funcion para agregar puntaje
    public void AddScore() 
    {//START AddScore
        //Incrementar puntaje 
        score++;

        //Actualizar el componente de texto de UI usando el valor de score
        scoreText.text = "x" + score;
    }//END AddScore

    //Funcion para reiniciar el juego
    public void RestartGame() 
    {//START RestartGame
        //Invocar a una funcion que carga la escena despues de 3 segundos
        Invoke("ReloadScene", 3f);
    }//END RestartGame

    //Funcion para cargar la escena de juego
    void ReloadScene() 
    {//START ReloadScene
        //Cargar la escena de juego usando la extension de sceneManagement de Unity
        UnityEngine.SceneManagement.SceneManager.LoadScene("SIU_Playground");
    }//END ReloadScene

    public void PutoPendejo()
    {
        Invoke("FinDelProyecto", 3);
        winScreen.SetActive(true);
    }
    void FinDelProyecto()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameSelector");
    }
}//END CLASS SIU_GameplayController
