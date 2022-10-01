using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_EnemySpawner : MonoBehaviour
{
    [Header("L�mites en Y")]
    public float minY = -4.4f;
    public float maxY = 4.3f;

    [Header("Asignaci�n de Enemigos")]
    public GameObject[] asteroidPrefabs;
    public GameObject[] enemyShipPrefab;

    [Header("Timer de Generaci�n")]
    public float timer = 2;

    private void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        float _posY = Random.Range(minY, maxY);
        Vector3 _temp = transform.position;
        _temp.y = _posY;
        if(Random.Range(0,2) > 0)
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], _temp, Quaternion.identity);
        else
            Instantiate(enemyShipPrefab[Random.Range(0, enemyShipPrefab.Length)], _temp, Quaternion.Euler(0, 0, 90));
        Invoke("SpawnEnemies", timer);
    }
}
