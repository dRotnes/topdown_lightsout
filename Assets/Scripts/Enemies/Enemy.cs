using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public bool isDead;
    public float attackDamage;
    public LayerMask playerLayer;
    public float startTimeBtwAttacks;

    public Animator animator;
    public FloatValue maxHealth;
    public Knockback knockback;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        health = maxHealth.initialValue;
    }
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hit");
        health -= 1;
    }
    public void Die()
    {
        animator.SetTrigger("die");
        isDead = true;
    }
    
}
