using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_ExplosiveObstacle : MonoBehaviour
{
    [Header("FX Obstáculo")]
    public GameObject explosionPrefab; 

    [Header("Daño al Jugador")]
    public int damage = 20;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Bullet")) 
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
