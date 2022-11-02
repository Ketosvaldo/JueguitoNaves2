using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_CameraFollow : MonoBehaviour
{
    //Variables Publicas
    [Header("Propiedades de C�mara")]
    public Transform target;
    public float distance = 6.5f;
    public float height = 3.5f;

    public float heightDamping = 3.25f;
    public float rotationDamping = 0.27f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    //Funcion de seguimiento al objetivo
    void FollowPlayer()
    {
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngle, 0f);
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }
}
