using UnityEngine;
using UnityEngine.UI;
public class ER_PlayerController : ER_BaseController
{
    [Header("Propiedades de Disparo")]
    public Transform bulletStartPoint;
    public GameObject bulletPrefab;
    public ParticleSystem shootFX;

    [HideInInspector]
    public bool canShoot;
    //Variables Privadas
    Rigidbody rb;
    Animator shootSliderAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootSliderAnim = GameObject.Find("UI_SLD_FireBar").GetComponent<Animator>();
        GameObject.Find("UI_BTN_ShootBtn").GetComponent<Button>().onClick.AddListener(ShootingControl);
        canShoot = true;
    }

    private void Update()
    {
        ControlMovementWithKeyboard();
        ChangeRotation();
        //ShootingControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer() 
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            MoveLeft();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            MoveRight();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            MoveFast();
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            MoveSlow();

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) 
            MoveStraight();

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            MoveNormal();
    }

    void ChangeRotation()
    {
        if(speed.x > 0) 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);
        else if(speed.x < 0) 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        else 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
    }

    public void ShootingControl()
    {/*
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletStartPoint.position, Quaternion.identity);
            bullet.GetComponent<ER_Bullet>().MoveBullet(2000f);
            shootFX.Play();
        }
     */
        if(Time.timeScale != 0)
        {
            if (canShoot)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletStartPoint.position, Quaternion.identity);
                bullet.GetComponent<ER_Bullet>().MoveBullet(2000);
                shootFX.Play();
                canShoot = false;
                shootSliderAnim.Play("Anim_ShootBar_FadeIn");
            }
        }
    }
}
