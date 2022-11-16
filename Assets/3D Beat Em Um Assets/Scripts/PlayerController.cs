using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 2;
    Rigidbody rb;
    public float horizontal, vertical;
    public bool isAttacking, isPunch, isKick;
    public int punchCombo = 0;
    public int kickCombo = 0;
    float timer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Move(horizontal, vertical);
        Attack();
        if (isAttacking)
            timer += Time.deltaTime;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (punchCombo == 0)
            {
                isAttacking = true;
                isPunch = true;
                punchCombo += 1;
            }
            else if (punchCombo == 1 && timer >= 0.24)
            {
                punchCombo += 1;
            }
            else if (punchCombo == 2 && timer >= 0.28)
            {
                punchCombo += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if(kickCombo == 0)
            {
                isAttacking = true;
                isKick = true;
            }
        }
    }

    void Move(float horizontal, float vertical)
    {
        if (!isAttacking)
        {
            if (horizontal != 0)
                rb.velocity = new Vector3(-horizontal * speed, rb.velocity.y, rb.velocity.z);
            if (vertical != 0)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -vertical * speed);
            if (vertical == 0 && horizontal == 0)
                rb.velocity = Vector3.zero;
        }
    }
}
