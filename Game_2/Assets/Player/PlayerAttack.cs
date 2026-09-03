using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 2;
    [SerializeField] private float attackRange = 1.0f;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;

    private Animator animator;


    public void OnAttack(InputValue value)
    {
        if(!value.isPressed)
        {
            return;
        }

        Debug.Log("Attack pressed");
        animator.SetTrigger("Attack");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position, 
            attackRange, 
            enemyLayer
            );

        Debug.Log("Enemy hit " + hitEnemies.Length);


        for(int i = 0; i < hitEnemies.Length; i++) 
        {

            Debug.Log("Object hit: " + hitEnemies[i].name);


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


    public void Start()
    {
        animator = GetComponent<Animator>();
    }
}
