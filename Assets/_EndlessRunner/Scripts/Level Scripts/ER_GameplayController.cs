using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_GameplayController : MonoBehaviour
{
    public static ER_GameplayController instance;

    [Header("Arreglos de Objetos")]
    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;

    [Header("Carriles de Objetos")]
    public Transform[] lanes;

    [Header("Tiempos para generar Obstaculos")]
    public float minObstacleDelay = 10f;
    public float maxObstacleDelay = 40f;

    //Variables Privadas
    float halfGroundSize;
    ER_BaseController baseController;

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<ER_GroundBlock>().halfLength;
        baseController = GameObject.FindGameObjectWithTag("Player").GetComponent<ER_BaseController>();
        StartCoroutine(GenerateObstaclesCo());
    }

    void MakeSingleton() 
    {
        if(instance == null) 
            instance = this;
        else if(instance != null) 
            Destroy(gameObject);
    }

    IEnumerator GenerateObstaclesCo()
    {
        float timer = Random.Range(minObstacleDelay, maxObstacleDelay) / baseController.speed.z;
        yield return new WaitForSeconds(timer);
        CreateObstacles(baseController.gameObject.transform.position.z + halfGroundSize);
        StartCoroutine(GenerateObstaclesCo());
    }

    //Metodo para generar obstaculos
    void CreateObstacles(float zPos)
    {
        int r = Random.Range(0, 10);
        if (0 <= r && r < 7)
        {
            int objectLane = Random.Range(0, lanes.Length);
            AddObstacle(new Vector3(lanes[objectLane].transform.position.x, 0f, zPos), Random.Range(0, obstaclePrefabs.Length));
            int zombieLane = 0;
            switch (objectLane)
            {
                case 0: zombieLane = Random.Range(0, 2) == 1 ? 1 : 2; break;
                case 1: zombieLane = Random.Range(0, 2) == 1 ? 0 : 2; break;
                case 2: zombieLane = Random.Range(0, 2) == 1 ? 1 : 0; break;
            }
            AddZombies(new Vector3(lanes[zombieLane].transform.position.x, 0.15f, zPos));
        }
    }
    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;
        switch (type) 
        {
            case 0: obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f); break;
            case 1: obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? 20 : -20, 0f); break;
            case 2: obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -10 : 10, 0f); break;
            case 3: obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f); break;
        }
        obstacle.transform.position = position;
    }
    void AddZombies(Vector3 position)
    {
        int count = Random.Range(0, 3) + 1;
        for (int i = 0; i < count; i++)
        {
            Vector3 shift = new(Random.Range(-0.5f, 0.5f), 0f, Random.Range(1f, 10f) * i);
            Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Length)], position + shift * i, Quaternion.identity);
        }
    }
}
