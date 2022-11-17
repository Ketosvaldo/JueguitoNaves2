using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.timer = 0.5f;
            player.isHitting = true;
            player.gameObject.GetComponent<PlayerHealth>().DecreaseHealth();
            Debug.Log("xd");
            AudioSource audioSource = transform.parent.GetComponent<AudioSource>();
            audioSource.clip = FindObjectOfType<EnemyAudioSource>().audioSource[1];
            audioSource.Play();
        }
    }
}
