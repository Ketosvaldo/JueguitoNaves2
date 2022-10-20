using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_PlayerController : ER_BaseController
{//START CLASS ER_PlayerController
    //Variables Publicas
    [Header("Propiedades de Disparo")]
    public Transform bulletStartPoint; //Punto de disparo del jugador
    public GameObject bulletPrefab; //GO de bala del Jugador
    public ParticleSystem shootFX; //REF a un efecto de disparo

    //Variables Privadas
    private Rigidbody RB; //REF COMP Rigidbody del Jugador

    private void Start()
    {//START Start
        //Inicializar la referencia RB
        RB = GetComponent<Rigidbody>();
    }//END Start

    private void Update()
    {//START Update
        //Llamar a la funcion que controla al Jugador con el teclado
        ControlMovementWithKeyboard();

        //Llamar a funcion para rotar al jugador
        ChangeRotation();

        //Llamar al metodo para disparar
        ShootingControl();
    }//END Update

    private void FixedUpdate()
    {//START FixedUpdate
        //Llamar al metodo que mueve al jugador
        MovePlayer();
    }//END FixedUpdate

    //Metodo para mover al jugador
    void MovePlayer() 
    {//START MovePlayer
        //Vamos a mover al RB de jugador a una posicion especifica
        //Aqui vamos a usar la posicion actual del RB y le vamos a sumar la velocidad 
        //multiplicada por el tiempo

        //speed es el vector delcarado en la clase ER_BaseController
        RB.MovePosition(RB.position + speed * Time.deltaTime);
    }//END MovePlayer

    //Metodo para controlar al jugador usando el teclado
    void ControlMovementWithKeyboard()
    {//START ControlMovementWithKeyboard
        //Vamos a obtener INPUTS DE TECLADO
        //---------------------------------INPUTS DE TECLAS PRESIONADAS
        //Movimiento a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {//START IF
            //Llamar a la funcion para mover al jugador a la izquierda
            MoveLeft();
        }//END IF

        //Movimiento a la derecha
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {//START IF
            //Llamar a la funcion para mover al jugador a la derecha
            MoveRight();
        }//END IF

        //Aumentar la velocidad
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {//START IF
            //Llamar a la funcion para Acelerar velocidad
            MoveFast();
        }//END IF

        //Disminuir la velocidad
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {//START IF
            //Llamar a la funcion para Reducir velocidad
            MoveSlow();
        }//END IF

        //---------------------------------INPUTS DE TECLAS SOLTADAS
        //Checar si se sueltan las teclas para ir a la izquierda para ir hacia adelante
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) 
        {//START IF
            //Llamar a la funcion para ir hacia adelante
            MoveStraight();
        }//END IF

        //Checar si se sueltan las teclas para ir a la derecha para ir hacia adelante
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {//START IF
            //Llamar a la funcion para ir hacia adelante
            MoveStraight();
        }//END IF

        //Checar si se sueltan las teclas para acelerar para restaurar velocidad
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {//START IF
            //Llamar a la funcion de velocidad normal
            MoveNormal();
        }//END IF

        //Checar si se sueltan las teclas para desacelerar para restaurar velocidad
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {//START IF
            //Llamar a la funcion de velocidad normal
            MoveNormal();
        }//END IF
    }//END ControlMovementWithKeyboard

    //Metodo para rotar al jugador
    void ChangeRotation()
    {//START ChangeRotation
        //Checar si la velocidad en X del jugador es mayor a 0
        if(speed.x > 0) 
        {//START IF
            //Rotar al jugador usando una interpolacion esferica
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }//END IF
        //Si no aplica lo anterior
        //Checar si la velocidad en X del jugador es menor a 0
        else if(speed.x < 0) 
        {//START ELSE IF
            //Rotar al jugador usando una interpolacion esferica
            //maxAngle es opuesto al ir a la izquierda
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }//END ELSE IF
        //Esto aplica cuando ninguno de los dos anteriores se cumple
        else 
        {//START ELSE
            //Rotar al jugador usando una interpolacion esferica
            //Rotacion Original
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }//END ELSE
    }//END ChangeRotation

    //Metodo para Disparar
    public void ShootingControl()
    {//START ShootingControl
        //Vamos a checar si se presiona el click izq
        //MouseButton 0 es click izq
        if (Input.GetMouseButtonDown(0)) 
        {//START IF
            //GO local que guarda la instancia de la bala
            //La bala va a aparecer en el punto de disparo 
            GameObject _bullet = Instantiate(bulletPrefab, bulletStartPoint.position, Quaternion.identity);

            //Llamar a la funcion MoveBullet del script de bala instanciada
            _bullet.GetComponent<ER_Bullet>().MoveBullet(2000f);

            //Iniciar Efecto de disparo
            //Activar el particleSystem
            shootFX.Play();
        }//END IF
    }//END ShootingControl
}//END CLASS ER_PlayerController
