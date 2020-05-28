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
    private bool _isDead;
    private bool _lifeGained;
    private bool _isInvencible;

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
    public GameObject fireBall;
    public GameObject playerLight;
    public HealthUI healthUI;

    public Transform attackPoint;

    [Space]
    [Header("Prefabs")]
    public GameObject[] attacksArray;
    public GameObject projectilePrefab;

    [Space]
    [Header("Layers")]

    public LayerMask enemyLayers;

    public int currentHealth;
    private ParticleSystem heartEffect;

    // Update is called once per frame

    private void Awake()
    {
        heartEffect = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        currentHealth = 1;
        heartEffect = GetComponent<ParticleSystem>();
        healthUI.SetHealth(currentHealth);
    }
    void Update()
    {
        
        if(_isDead == false)
        {

            GetInputs();
            
        }
            
        
        if (currentHealth<=0)
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


        if(Time.time >= nextAttack)
        {
            if(Input.GetButtonDown("Fire1")) {
                _isAttacking = true;
                Attack();
                nextAttack = Time.time + 1f / attackRate;
               
            }

        }

        if (Input.GetKeyDown("x"))
        {
            if(fireBall.activeSelf == true)
            {
                fireBall.SetActive(false);
                playerLight.SetActive(false);

            }
            else
            {
                fireBall.SetActive(true);
                playerLight.SetActive(true);

            }
        }

    }

    private void LateUpdate()
    {

        if(movement != Vector2.zero && _isAttacking == false && _isDead == false )
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking 1"))
        {
            _isAttacking = true;
        }
        else {
            _isAttacking = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            _isDead = true;
        }
        else
        {
            _isDead = false;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Life"))
        {
            _lifeGained = true;
        }
        else
        {
            _lifeGained = false;
        }

        animator.SetFloat("velocity", movement.sqrMagnitude);


    }
    private void FixedUpdate()
    {
        if (_isDead == false)
        {
            if (_isAttacking)
            {
                rigidbody.velocity = Vector2.zero;
            }

            if (_lifeGained)
            {
                rigidbody.velocity = Vector2.zero;
            }

            rigidbody.velocity = movement * movementSpeed * BASE_SPEED;
        }

        else{
            rigidbody.velocity = Vector2.zero;
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

    public void TakeDamage()
    {
        if(_isInvencible == false)
        {

            Debug.Log("hurt");
            animator.SetTrigger("hit");
            currentHealth -= 1;
            healthUI.SetHealth(currentHealth);
            StartCoroutine(Invencible());
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        GetComponent<BoxCollider2D>().enabled = false;
        
    }

    public void Fall()
    {
        animator.SetTrigger("fall");
        
    }

    public void GainHealth(int life)
    {
        currentHealth += life;
        healthUI.SetHealth(currentHealth);
    }

    private IEnumerator Invencible()
    {
        _isInvencible = true;
        yield return new WaitForSeconds(1f);
        _isInvencible = false;
    }
}