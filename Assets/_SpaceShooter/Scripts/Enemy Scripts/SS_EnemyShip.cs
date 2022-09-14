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
    [Header("Limite de Enemigo")]
    public float boundX = -10;
    [Header("Asignaciones")]
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public bool destroy = false;
    Animator anim;
    AudioSource explosionSound;

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
        if (destroy)
        {
            anim.Play("Anim_SS_Enemy_Destroy") || anim.Play("Anim_SS_Asteroid_Destroy");
        }
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
        GameObject _bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1, 3));
        }
    }
}