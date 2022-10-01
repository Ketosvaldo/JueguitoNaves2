using UnityEngine;
using TMPro;

public class SS_DisplayLife : MonoBehaviour
{
    SS_Life vidas;
    TextMeshProUGUI displayText;

    private void Start()
    {
        vidas = FindObjectOfType<SS_Life>();
        displayText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        displayText.text = "Vidas: " + vidas.vidas;
    }
}
