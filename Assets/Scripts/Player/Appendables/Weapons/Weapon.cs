using UnityEngine;


public class Weapon : MonoBehaviour
{
    public string weapon_name;
    public string weapon_type;
    public float weapon_damage;
    public Transform attackPoint;
    public float attackRange;
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
            enemy.GetComponent<Enemy>().TakeDamage(weapon_damage);
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
