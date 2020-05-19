using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Atributes")]
    public float BASE_SPEED= 1f;

    private int _idleType;
    private bool _isAttacking;
    private bool _takeDamage;
    private GameObject _selectedAttack;

    public float attackRange = 0.5f;

    public float attackRate = 1f;
    private float nextAttack = 0f;

    [Space]
    [Header("Statistics")]
    public Vector2 movement;
    public float movementSpeed;

    public int[] attacks;

    [Space]
    [Header("References")]

    public Rigidbody2D rigidbody;
    public Animator animator;

    public Transform attackPoint;

    [Space]
    [Header("Prefabs")]
    public GameObject[] attacksArray;
    public GameObject projectilePrefab;

    [Space]
    [Header("Layers")]

    public LayerMask enemyLayers;

    public int totalHealth = 10;
    public int currentHealth;
    // Update is called once per frame

    private void Start()
    {
        currentHealth = totalHealth;
    }
    void Update()
    {
        GetInputs();

        if (movement.x > 0.5f) {
            _idleType = 0;
        }
        else if (movement.x < -0.5f)
        {
            _idleType = 1;
        }

        if (movement.y > 0.5f)
        {
            _idleType = 2;
        }
        else if (movement.y < -0.5f)
        {
            _idleType = 3;
        }

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void GetInputs()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movement.magnitude, 0.0f, 1.0f);
        
        if(_isAttacking == true){
            movement = Vector2.zero;
        }

        if (_takeDamage == true)
        {
            movement = Vector2.zero;
        }
        movement.Normalize();

        AttackSelection();

        if(Time.time >= nextAttack)
        {
            if(Input.GetButtonDown("Fire1")) {
                _isAttacking = true;
                Attack();
                nextAttack = Time.time + 1f / attackRate;
               
            }

        }

    }

    private void LateUpdate()
    {
        if(movement != Vector2.zero && _isAttacking == false)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetInteger("idleType", _idleType);
        }
        animator.SetFloat("velocity", movement.sqrMagnitude);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking 1"))
        {
            _isAttacking = true;
        }
        else {
            _isAttacking = false;
        }

        

        

    }
    private void FixedUpdate()
    {
        Debug.Log(_isAttacking);
        if (_isAttacking) { rigidbody.velocity = Vector2.zero; }
        rigidbody.velocity = movement * movementSpeed * BASE_SPEED;

    }

    void AttackSelection()
    {
        for(int i=0; i<attacksArray.Length;i++)
        {

            if (Input.GetKeyDown(KeyCode.Alpha0 + i + 1)) { 
        
                _selectedAttack = attacksArray[i];
                animator.SetInteger("selectedAttack", i);
            }
        }
    }

    void Attack()
    {
        rigidbody.velocity = Vector2.zero;
        animator.SetTrigger("attack");

        Collider2D[] hitArray = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitArray)
        {
            Debug.Log("IT WORKS" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        animator.SetTrigger("hit");
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}