using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 2;


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " hit , remaining health: " + health);


            if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " destroyed");
        }
    }
}
