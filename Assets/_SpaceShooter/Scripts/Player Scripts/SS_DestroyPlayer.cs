using UnityEngine;

public class SS_DestroyPlayer : MonoBehaviour
{
    Animator anim;
    AudioSource audioSource;
    BoxCollider2D boxCollider;
    SS_Score score;
    SS_Life vidas;
    SS_PlayerController controller;
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        score = FindObjectOfType<SS_Score>();
        vidas = FindObjectOfType<SS_Life>();
        controller = GetComponent<SS_PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            boxCollider.enabled = false;
            anim.Play("SS_Player_Destroy");
            audioSource.enabled = true;
            score.DecreaseScore();
            vidas.DecreaseLife();
            controller.enabled = false;
            if(vidas.vidas != 0)
                Invoke("Restart", 2);
        }
    }

    void Restart()
    {
        transform.position = new Vector2(transform.position.x, 0);
        controller.enabled = true;
        boxCollider.enabled = true;
        anim.Play("SS_Player_Idle");
        audioSource.enabled = false;
    }
}
