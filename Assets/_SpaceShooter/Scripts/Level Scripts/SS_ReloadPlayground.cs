using UnityEngine;
using UnityEngine.SceneManagement;

public class SS_ReloadPlayground : MonoBehaviour
{
    void Awake()
    {
        Invoke("LoadScene", 5);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("SS_Playground");
    }
}
