using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 2;

    public static event Action EnemyDied;


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " hit , remaining health: " + health);


            if(health <= 0)
        {
            EnemyDied?.Invoke();
            Destroy(gameObject);
            Debug.Log(gameObject.name + " destroyed");
        }
    }
}
