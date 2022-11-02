using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_ZombieScript : MonoBehaviour
{
    UI_Score score;
    [Header("FX de Destrucción")]
    public GameObject bloodFXPrefab;

    [Header("Propiedades del Zombie")]
    public float speed = 2f;

    //Variables Privadas
    private Rigidbody rb;
    private bool isAlive;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isAlive = true;
        score = FindObjectOfType<UI_Score>();
    }

    private void Update()
    {
        if (isAlive) 
            rb.velocity = new Vector3(0f, 0f, -speed);
        if(transform.position.y < -10f) 
            Destroy(gameObject);
    }
    void Die() 
    {
        isAlive = false;
        rb.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet")) 
        {
            Instantiate(bloodFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject, 3f);
            Die();
            score.UpdateScore();
        }
    }
}
