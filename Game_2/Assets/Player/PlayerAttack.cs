using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 2;
    [SerializeField] private float attackRange = 1.0f;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;


    public void OnAttack(InputValue value)
    {
        if(!value.isPressed)
        {
            return;
        }

        Debug.Log("Attack pressed");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position, 
            attackRange, 
            enemyLayer
            );


        for(int i = 0; i < hitEnemies.Length; i++) 
        {
            EnemyHealth enemyHealth = hitEnemies[i].GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);

            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
