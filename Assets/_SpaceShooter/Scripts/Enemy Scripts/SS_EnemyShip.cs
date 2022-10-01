using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_EnemyShip : MonoBehaviour
{
    [Header("Velocidades de Enemigo")]
    public float speed = 5;
    public float rotateSpeed = 50;
    [Header("Propiedades de Enemigo")]
    public bool canShoot;
    public bool canRotate;
    public bool canMove = true;
    public float attackTimer;
    [Header("Limite de Enemigo")]
    public float boundX = -10;
    [Header("Asignaciones")]
    public Transform[] attackPoint;
    public GameObject bulletPrefab;
    Animator anim;
    AudioSource explosionSound;
    float counter;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (canRotate)
        {
            rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20);
            if (Random.Range(0, 2) > 0)
                rotateSpeed *= -1;
        }
    }

    private void Update()
    {
        MoveEnemy();
        RotateEnemy();
        if(counter >= attackTimer)
            StartShooting();
        counter += Time.deltaTime;
    }

    public void DestroyEnemy()
    {
        anim.Play("Anim_SS_Enemy_Destroy");
        explosionSound.enabled = true;
        canShoot = false;
        if (GetComponent<BoxCollider2D>())
            GetComponent<BoxCollider2D>().enabled = false;
        else
            GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }

    void MoveEnemy()
    {
        Vector3 _temp = transform.position;
        if (canMove)
        {
            _temp.x -= speed * Time.deltaTime;
            transform.position = _temp;
            if(_temp.x < boundX)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, attackPoint[0].position, Quaternion.identity);
            if (attackPoint[1])
                Instantiate(bulletPrefab, attackPoint[1].position, Quaternion.identity);
            counter = 0;
        }
    }
}