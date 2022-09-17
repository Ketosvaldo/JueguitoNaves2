using UnityEngine;

public class SS_Bullet : MonoBehaviour
{
    public float Speed = 6f;
    public float deactivateTimer = 3f;
    SS_EnemyShip enemie;
    SS_Score score;
    private void Start()
    {
        score = GameObject.FindObjectOfType<SS_Score>();
        Destroy(this.gameObject, deactivateTimer);
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 _temp = transform.position;
        if (gameObject.CompareTag("Player"))
            _temp.x += Speed * Time.deltaTime;
        else
            _temp.x -= Speed * Time.deltaTime;
        transform.position = _temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemie = collision.gameObject.GetComponent<SS_EnemyShip>();
            switch (collision.gameObject.name)
            {
                case "SS_Asteroid1(Clone)": score.score += 100; break;
                case "SS_Asteroid2(Clone)": score.score += 200; break;
                case "SS_Enemy(Clone)": score.score += 300; break;
            }
            enemie.destroy = true;
            Destroy(gameObject);
        }
    }
}