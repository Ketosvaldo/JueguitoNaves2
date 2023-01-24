using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGame : MonoBehaviour
{
    public GameObject firstPanel, secondPanel;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void changePanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }
}
