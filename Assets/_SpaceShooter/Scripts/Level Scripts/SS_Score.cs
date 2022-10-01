using UnityEngine;
using UnityEngine.SceneManagement;
public class SS_Score : MonoBehaviour
{
    SS_Life life;
    public int score;
    int counter;
    void Start()
    {
        score = 0;
        counter = 0;
        life = FindObjectOfType<SS_Life>();
    }

    public void DecreaseScore()
    {
        score -= 500;
        if (score <= 0)
            score = 0;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        counter += points;
        if(counter >= 10000)
        {
            counter -= 10000;
            life.vidas += 1;
        }
        if(score >= 30000)
        {
            SceneManager.LoadScene("SS_VictoryScreen");
        }
    }
}
