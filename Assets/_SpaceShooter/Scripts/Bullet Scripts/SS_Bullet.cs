using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Bullet : MonoBehaviour
{
    public float Speed = 6f;
    public float deactivateTimer = 3f;
    SS_EnemyShip enemie;

    private void Start()
    {
        Destroy(this.gameObject, deactivateTimer);
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 _temp = transform.position;
        _temp.x += Speed * Time.deltaTime;

        transform.position = _temp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            enemie = collision.gameObject.GetComponent<SS_EnemyShip>();
            enemie.destroy = true;
        }
    }
}