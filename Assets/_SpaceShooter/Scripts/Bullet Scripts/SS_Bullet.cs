using UnityEngine;

public class SS_Bullet : MonoBehaviour
{
    public float Speed = 6f;
    public float deactivateTimer = 3f;
    public bool PlayerBullet;
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
        if (collision.tag == "Enemy" && PlayerBullet)
        {
            enemie = collision.gameObject.GetComponent<SS_EnemyShip>();
            switch (collision.gameObject.name)
            {
                case "SS_Asteroid1(Clone)": score.IncreaseScore(100); enemie.DestroyEnemy(); break;
                case "SS_Asteroid2(Clone)": score.IncreaseScore(200); enemie.DestroyEnemy(); break;
                case "SS_Asteroid3(Clone)": score.IncreaseScore(500); enemie.DestroyEnemy(); break;
                case "SS_Enemy(Clone)": score.IncreaseScore(300); enemie.DestroyEnemy(); break;
                case "SS_Enemy 1(Clone)": score.IncreaseScore(600); enemie.DestroyEnemy(); break;
                default: Destroy(collision.gameObject); break;
            }
            Destroy(gameObject);
        }
    }
}