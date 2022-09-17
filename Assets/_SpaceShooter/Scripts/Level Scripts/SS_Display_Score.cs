using UnityEngine;
using TMPro;

public class SS_Display_Score : MonoBehaviour
{
    SS_Score Score;
    TextMeshProUGUI DisplayText;
    void Start()
    {
        Score = FindObjectOfType<SS_Score>();
        DisplayText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        DisplayText.text = Score.score.ToString();
    }
}
