using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 6;
    EnemyMovement enemy;
    AudioSource audioSource;
    EnemyAudioSource clip;
    void Start()
    {
        enemy = GetComponent<EnemyMovement>();
        audioSource = GetComponent<AudioSource>();
        clip = GetComponent<EnemyAudioSource>();
    }

    public void DecreaseHealth()
    {
        health -= 1;
        if (health == 0)
        {
            enemy.isDeath = true;
            GetComponentInChildren<Animator>().Play("Death");
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            audioSource.clip = clip.audioSource[0];
            audioSource.Play();
            GameManager.DecreaseCounter();
        }
    }
}
