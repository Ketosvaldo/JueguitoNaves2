using UnityEngine;
using UnityEngine.SceneManagement;

public class SS_ReloadPlayground : MonoBehaviour
{
    void Awake()
    {
        Invoke("LoadScene", 3);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("GameSelector");
    }
}
