using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider collide;
    public bool isHitting, isAttacking, isKnockdown, isDeath;
    const float speed = 1.5f;
    public float lag = 0;
    Transform player;
    Animator anim;
    EnemyCollisions collisions;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
        collide = GetComponent<CapsuleCollider>();
        collisions = FindObjectOfType<EnemyCollisions>();
    }

    void Update()
    {
        if (!isDeath)
        {
            Move();
            Attack(); 
            States();
        }
        else
            Destroy(gameObject, 2.5f);
    }

    void Move()
    {
        if (!isAttacking && !isHitting)
        {
            transform.LookAt(player);
            rb.velocity = transform.forward * speed;
            anim.Play("Walk");
        }
        else
            rb.velocity = Vector3.zero;
    }

    void Attack()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 1 && lag == 0)
        {
            isAttacking = true;
            float random = Random.Range(0, 2);
            collisions.enemyAttack = random;
            lag = 3;
            anim.Play("Attack" + random);
        }
    }

    void States()
    {
        if (isAttacking || isHitting || isKnockdown)
            lag -= Time.deltaTime;
        if (lag <= 0)
        {
            lag = 0;
            isAttacking = false;
            isHitting = false;
            isKnockdown = false;
            rb.useGravity = true;
            collide.enabled = true;
        }
        if (isKnockdown)
        {
            collide.enabled = false;
            rb.useGravity = false;
        }
    }
}
