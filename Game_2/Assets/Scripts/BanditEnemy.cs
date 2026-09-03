using UnityEngine;

public class BanditEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float enemyScale = 1.5f;

    private Transform player;
    private Rigidbody2D rb2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        float direction = player.position.x - transform.position.x;

        if (direction > 0)
        {
            rb2d.linearVelocity = new Vector2(moveSpeed, rb2d.linearVelocity.y);
            transform.localScale = new Vector3(-enemyScale, enemyScale, 1);
        }
        else if (direction < 0)
        {
            rb2d.linearVelocity = new Vector2(-moveSpeed, rb2d.linearVelocity.y);
            transform.localScale = new Vector3(enemyScale, enemyScale, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();

            if(playerStats != null)
        {
            playerStats.TakeDamage(damage);
        }
    }
}
