using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerController player;
    AudioSource audioSource;
    PlayerAudioClips clips;
    ParticleSpawn spawnParticle;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        audioSource = GetComponentInParent<AudioSource>();
        clips = GetComponentInParent<PlayerAudioClips>();
        spawnParticle = GetComponentInParent<ParticleSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            enemy.isHitting = true;
            enemy.isAttacking = false;
            if (player.punchCombo == 3 || player.kickCombo == 2)
            {
                if (player.punchCombo == 3)
                    spawnParticle.InstantiateParticles(0);
                else
                    spawnParticle.InstantiateParticles(3);
                float random = Random.Range(0, 10);
                if (random > 7)
                {
                    enemy.isKnockdown = true;
                    enemy.GetComponentInChildren<Animator>().Play("KnockDown");
                    enemy.lag = 2.6f;
                    audioSource.clip = clips.clips[3];
                }
                else
                {
                    enemy.GetComponentInChildren<Animator>().Play("Hit" + Random.Range(0, 2));
                    enemy.lag = 1.5f;
                    audioSource.clip = clips.clips[2];
                }
            }
            else
            {
                enemy.GetComponentInChildren<Animator>().Play("Hit" + Random.Range(0, 2));
                audioSource.clip = clips.clips[1];
                enemy.lag = 1.5f;
            }
            enemy.gameObject.GetComponent<EnemyHealth>().DecreaseHealth();
            audioSource.Play();
            if (player.punchCombo == 1)
                spawnParticle.InstantiateParticles(0);
            else if (player.punchCombo == 2)
                spawnParticle.InstantiateParticles(1);
            else if (player.kickCombo == 1)
                spawnParticle.InstantiateParticles(2);
        }
    }
}
