using UnityEngine;


public class Weapon : MonoBehaviour
{
    public Transform attackPoint;
    public int attackDamage;
    public float attackRange = 1;
    public LayerMask enemyLayer;
    private Knockback knockback;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }
    public void Attack()
    {

        Collider2D[] hitArray = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D collider in hitArray)
        {
            GameObject enemy = collider.gameObject;
            knockback.Knock(enemy);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
