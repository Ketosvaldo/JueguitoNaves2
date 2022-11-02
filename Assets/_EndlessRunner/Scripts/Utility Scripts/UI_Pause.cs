using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Pause : MonoBehaviour
{
    public GameObject PausaContainer;
    public ER_PlayerController control;
    public void EnterPause()
    {
        PausaContainer.SetActive(true);
        Time.timeScale = 0;
        control.enabled = false;
    }

    public void Continue()
    {
        PausaContainer.SetActive(false);
        Time.timeScale = 1;
        control.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
