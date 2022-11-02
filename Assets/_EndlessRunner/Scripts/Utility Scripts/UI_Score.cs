using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;
    public GameObject victoryObject;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score == 100)
        {
            victoryObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
