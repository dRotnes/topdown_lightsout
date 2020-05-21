using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform attackPoint;
    public int attackDamage;
    public float attackRange;
    public LayerMask enemyLayer;
    /*Collider2D[] hitArray = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    foreach(Collider2D enemy in hitArray)
    {
        Debug.Log("IT WORKS" + enemy.name);
    }*/

    
}
