using UnityEngine;

public class ER_BaseController : MonoBehaviour
{
    [Header("Vector de Velocidad")]
    public Vector3 speed;

    [Header("Valores de Velocidad")]
    public float xSpeed = 8f;
    public float zSpeed = 15f;

    [Header("Features de Movimiento")]
    public float acceleration = 30f;
    public float deceleration = 10f;

    protected float rotationSpeed = 10f; 
    protected float maxAngle = 10f;

    [Header("Valores de Pitch de Audio")]
    public float lowSoundPitch;
    public float normalSoundPitch;
    public float highSoundPitch;

    [Header("Clips de Audio")]
    public AudioClip engine_OnSound;
    public AudioClip engine_OffSound;

    //Variables Privadas
    bool isSlow;
    AudioSource soundManager;

    private void Awake()
    {
        soundManager = GetComponent<AudioSource>();
        speed = new Vector3(0f, 0f, zSpeed);
    }
    protected void MoveLeft() 
    {
        speed = new Vector3(-xSpeed / 2f, 0f, speed.z); 
    }

    protected void MoveRight()
    {
        speed = new Vector3(xSpeed / 2f, 0f, speed.z);
    }

    protected void MoveStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void MoveNormal()
    {
        if (isSlow) 
        {
            isSlow = false;
            soundManager.Stop();
            soundManager.clip = engine_OnSound;
            soundManager.volume = 0.3f;
            soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, zSpeed);
    }

    protected void MoveSlow()
    {
        if (!isSlow)
        {
            isSlow = true;
            soundManager.Stop();
            soundManager.clip = engine_OffSound;
            soundManager.volume = 0.3f;
            soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, deceleration);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, acceleration);
    }
}
