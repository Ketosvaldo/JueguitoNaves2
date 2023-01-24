using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Extension para usar DOTween

public class SIU_LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatform, endPlatform, platformPrefab; //GO para plataformas

    private float blockWidth = 0.5f; //Ancho de bloque
    private float blockHeight = 0.2f; //Alto de bloque

    [Header("Cantidad de Plataformas a generar")]
    [SerializeField]
    private int amountToSpawn = 100; //Cantidad de bloques a generar
    private int startAmount = 0; //Cantidad inicial de bloques

    private Vector3 lastPosition; //Posicion del bloque generado

    private List<GameObject> spawnedPlatforms = new List<GameObject>(); //Lista de GOs bloques/plataformas

    [Header("Prefab de Jugador")]
    [SerializeField]
    private GameObject playerPrefab; //GO de Jugador

    private void Awake()
    {
        InstantiateLevel();
        Screen.SetResolution(1080, 1920, true);
    }
    void InstantiateLevel()
    {
        for (int _i = startAmount; _i < amountToSpawn; _i++)
        {
            GameObject _newPlatform; 
            if(_i == 0) 
                _newPlatform = Instantiate(startPlatform);
            else if(_i == amountToSpawn - 1) 
            {
                _newPlatform = Instantiate(endPlatform);
                _newPlatform.tag = "EndPlatform";
            }
            else 
                _newPlatform = Instantiate(platformPrefab);
            _newPlatform.transform.parent = transform;
            spawnedPlatforms.Add(_newPlatform);
            if(_i == 0) 
            {
                lastPosition = _newPlatform.transform.position;
                Vector3 _temp = lastPosition;
                _temp.y += 0.1f;
                Instantiate(playerPrefab, _temp, Quaternion.identity);
                continue;
            }

            int _left = Random.Range(0, 2);

            if(_left == 0) 
            {
                _newPlatform.transform.position = new Vector3(
                    lastPosition.x - blockWidth,
                    lastPosition.y + blockHeight, 
                    lastPosition.z
                );
            }
            else 
            {
                _newPlatform.transform.position = new Vector3(
                    lastPosition.x,
                    lastPosition.y + blockHeight,
                    lastPosition.z + blockWidth
                );
            }

            lastPosition = _newPlatform.transform.position;

            if (_i < 25)
            {
                float _endPosY = _newPlatform.transform.position.y;
                _newPlatform.transform.position = new Vector3(
                    _newPlatform.transform.position.x,
                    _newPlatform.transform.position.y - blockHeight * 3f,
                    _newPlatform.transform.position.z
                );
                _newPlatform.transform.DOLocalMoveY(_endPosY, 0.3f).SetDelay(_i * 0.1f);
            }
        }
    }
}
