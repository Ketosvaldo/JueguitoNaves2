using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    static int EnemyCounter;
    static GameObject winScreen;
    static GameObject loseScreen;
    static bool win = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCounter = FindObjectsOfType<EnemyHealth>().Length;
        winScreen = GameObject.FindGameObjectWithTag("winScreen");
        loseScreen = GameObject.FindGameObjectWithTag("loseScreen");
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        win = false;
        timer = 0;
    }

    private void Update()
    {
        if (win)
        {
            timer += Time.deltaTime;
            if (timer > 3)
                ReturnScene();
        }
    }
    static public void DecreaseCounter()
    {
        EnemyCounter--;
        if (EnemyCounter == 0)
        {
            winScreen.SetActive(true);
            win = true;
        }   
    }

    static public void LoseLevel()
    {
        loseScreen.SetActive(true);
    }

    public void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    void ReturnScene()
    {
        SceneManager.LoadScene("GameSelector");
    }
}
