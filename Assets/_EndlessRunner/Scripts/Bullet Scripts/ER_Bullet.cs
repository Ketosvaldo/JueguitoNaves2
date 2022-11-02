using UnityEngine;

public class ER_Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    //Funcion para mover la bala
    public void MoveBullet(float speed)
    {
        rb.AddForce(transform.forward.normalized * speed);
        Destroy(gameObject, 5);
    }

    //Metodo para evaluar entradas a colisiones
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
