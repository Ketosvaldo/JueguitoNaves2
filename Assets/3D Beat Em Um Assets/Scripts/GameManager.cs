using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    static int EnemyCounter;
    static GameObject winScreen;
    static GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCounter = FindObjectsOfType<EnemyHealth>().Length;
        winScreen = GameObject.FindGameObjectWithTag("winScreen");
        loseScreen = GameObject.FindGameObjectWithTag("loseScreen");
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    static public void DecreaseCounter()
    {
        EnemyCounter--;
        if (EnemyCounter == 0)
            winScreen.SetActive(true);
    }

    static public void LoseLevel()
    {
        loseScreen.SetActive(true);
    }

    public void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
