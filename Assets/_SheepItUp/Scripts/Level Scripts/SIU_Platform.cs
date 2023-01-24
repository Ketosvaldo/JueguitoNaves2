using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Extension para usar DOTween

public class SIU_Platform : MonoBehaviour
{//START CLASS SIU_Platform
    [Header("Arreglo de Picos")]
    [SerializeField]
    private Transform[] spikes;

    [Header("Colectibles")]
    [SerializeField]
    private GameObject coinPrefab;

    private bool fallDown;

    private void Start()
    {
        ActivatePlatform();
    }
    void ActivateSpike()
    {
        int _index = Random.Range(0, spikes.Length);
        spikes[_index].gameObject.SetActive(true);
        spikes[_index].DOLocalMoveY(0.7f, 1.3f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(3f, 5f));
    }

    void AddCoin() 
    {
        GameObject _coin = Instantiate(coinPrefab);
        _coin.transform.position = transform.position;
        _coin.transform.SetParent(transform);
        _coin.transform.DOLocalMoveY(1f, 0f);
    }
    void ActivatePlatform()
    {
        int _chance = Random.Range(0, 100);
        if(_chance > 70) 
        {
            int _type = Random.Range(0, 8);
            switch (_type)
            {
                case 0: ActivateSpike(); break;
                case 1:
                    case 4: AddCoin(); break;
                case 2: fallDown = true; break;
                case 7: ActivatePlatform(); break;
            }
        }
    }

    void InvokeFalling()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision _other)
    {
        if(_other.gameObject.CompareTag("Player")) 
        {
            if (fallDown) 
            {
                fallDown = false;
                Invoke("InvokeFalling", 1f);
            }
        }
    }
}
