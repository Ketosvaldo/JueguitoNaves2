using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIU_SoundManager : MonoBehaviour
{//START CLASS SIU_SoundManager
    //Variables Publicas
    public static SIU_SoundManager instance; //Variable Singleton de esta clase

    //Variables Privadas
    [SerializeField]
    private AudioSource gameStart, gameEnd, coinSound, jumpSound; //Sonidos de juego

    private void Awake()
    {//START Awake
        //SINGLETON
        if (instance == null)
            instance = this;
    }//END Awake

    //FUNCIONES DE SONIDOS
    //INICIO DE JUEGO
    public void GameStartSound()
    {//START GameStartSound
        //Reproducir AudioSource
        gameStart.Play();
    }//END GameStartSound

    //FIN DE JUEGO
    public void GameEndSound()
    {//START GameEndSound
        //Reproducir AudioSource
        gameEnd.Play();
    }//END GameEndSound

    //MONEDAS
    public void PickupCoin()
    {//START PickupCoin
        //Reproducir AudioSource
        coinSound.Play();
    }//END PickupCoin

    //SALTO
    public void JumpSound()
    {//START JumpSound
        //Reproducir AudioSource
        jumpSound.Play();
    }//END JumpSound
}//END CLASS SIU_SoundManager
