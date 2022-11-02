using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_GroundBlock : MonoBehaviour
{
    [Header("Propiedades de Pieza de Terreno")]
    public Transform otherBlock;
    public float halfLength = 100f;

    //Variables Privadas
    Transform player;
    const float endOffset = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        MoveBlock();
    }

    void MoveBlock() 
    {
        if(transform.position.z + halfLength < player.transform.position.z - endOffset) 
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, otherBlock.position.z + halfLength * 2);
        }
    }
}
