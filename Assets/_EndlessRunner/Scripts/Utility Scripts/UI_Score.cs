using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;
    public GameObject victoryObject;
    bool win = false;
    float timer;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    private void Update()
    {
        if (win)
        {
            timer += Time.deltaTime;
            if(timer > 3)
                SceneManager.LoadScene("GameSelector");
        }
    }
    public void UpdateScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score == 100)
        {
            victoryObject.SetActive(true);
            Time.timeScale = 1;
            win = true;
        }
    }
}
