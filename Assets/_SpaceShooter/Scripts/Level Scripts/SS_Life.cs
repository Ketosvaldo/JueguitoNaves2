using UnityEngine;
using UnityEngine.SceneManagement;
public class SS_Life : MonoBehaviour
{
    public int vidas;
    void Start()
    {
        vidas = 3;
    }
    
    public void DecreaseLife()
    {
        vidas -= 1;
        if (vidas == 0)
            Invoke("GameOver", 1);
    }

    void GameOver()
    {
        SceneManager.LoadScene("SS_GameOver");
    }
}
