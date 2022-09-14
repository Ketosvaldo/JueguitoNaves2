using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float minY, maxY;
    public float attackTimer = 0.4f;

    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;
    private float currentAttackTimer;
    private bool canAttack;

    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        Vector2 _temp = transform.position;
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            _temp.y += speed * Time.deltaTime;
            if (_temp.y > maxY)
                _temp.y = maxY;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            _temp.y -= speed * Time.deltaTime;
            if (_temp.y < minY)
                _temp.y = minY;
        }
        transform.position = new Vector2(transform.position.x, _temp.y);
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
            canAttack = true;
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            canAttack = false;
            attackTimer = 0;
            Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
        }
    }
}