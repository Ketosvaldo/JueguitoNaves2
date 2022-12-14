using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    ParticleSpawn spawnParticle;
    public float enemyAttack;
    private void Start()
    {
        spawnParticle = GetComponent<ParticleSpawn>();
    }
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
            spawnParticle.InstantiateParticles((int)enemyAttack);
        }
    }
}
