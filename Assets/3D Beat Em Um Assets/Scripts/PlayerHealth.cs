using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public Slider healthSlider;
    PlayerController player;
    AudioSource audioSource;
    private void Start()
    {
        player = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void DecreaseHealth()
    {
        health -= 1;
        healthSlider.value = health;
        if (health == 0)
        {
            player.isDeath = true;
            audioSource.clip = GetComponent<PlayerAudioClips>().clips[0];
            audioSource.Play();
        }
    }
}
