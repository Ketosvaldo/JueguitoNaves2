using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 2;
    Rigidbody rb;
    public float horizontal, vertical;
    public bool isAttacking, isHitting, isDeath;
    public int punchCombo = 0;
    public int kickCombo = 0;
    public float timer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isDeath)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            Move(horizontal, vertical);
            Attack();
            if (isAttacking || isHitting)
                timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                isAttacking = false;
                isHitting = false;
                punchCombo = 0;
                kickCombo = 0;
            }
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (punchCombo == 0)
            {
                isAttacking = true;
                punchCombo += 1;
                timer = 0.26f;
            }
            else if (punchCombo == 1)
            {
                punchCombo += 1;
                timer += 0.3f;
            }
            else if (punchCombo == 2 && timer >= 0.28)
            {
                punchCombo += 1;
                timer = 0.5f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (kickCombo == 0)
            {
                isAttacking = true;
                timer = 0.5f;
                kickCombo += 1;
            }
            else if (kickCombo == 1)
            {
                kickCombo += 1;
                timer = 0.7f;
            }
        }
    }

    void Move(float horizontal, float vertical)
    {
        if (!isAttacking && !isHitting)
        {
            if (horizontal != 0)
                rb.velocity = new Vector3(-horizontal * speed, rb.velocity.y, rb.velocity.z);
            if (vertical != 0)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -vertical * speed);
            if (vertical == 0 && horizontal == 0)
                rb.velocity = Vector3.zero;
        }
        if (horizontal > 0 && !isAttacking && !isHitting)
            transform.eulerAngles = new Vector3(0, -90, 0);
        else if (horizontal < 0 && (!isAttacking || !isHitting))
            transform.eulerAngles = new Vector3(0, 90, 0);
    }
}
