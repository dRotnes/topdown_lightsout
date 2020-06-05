using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Atributes")]
    public float BASE_SPEED = 1f;

    private bool _takeDamage;
    private bool _isDead;
    private bool _lifeGained;
    private bool _isInvencible;
    private bool _isAttacking;

    [Space]
    [Header("Statistics")]
    public Vector2 movement;
    public float movementSpeed;


    [Space]
    [Header("References")]

    public Rigidbody2D _rigidbody;
    public Animator animator;
    public GameObject fireBall;
    public GameObject playerLight;
    public HealthUI healthUI;
    public GameObject weapon;
    public SignalSend playerHealthSignal;
    public FloatValue currentHealth;


    /*[Space]
    [Header("Prefabs")]*/

    void Update()
    {

        if (_isDead == false)
        {

            GetInputs();
            
        }
            
        
        if (currentHealth.RuntimeValue<=0)
        {
            
            Die();
            

        }

    }

    void GetInputs()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movement.magnitude, 0.0f, 1.0f);

        if (_isAttacking == true)
        {
            movement = Vector2.zero;
        }

        if (_takeDamage == true)
        {
            movement = Vector2.zero;
        }
        movement.Normalize();

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

        if (Input.GetKeyDown("v")) {
            animator.SetTrigger("attack");
           
        }

    }

    private void LateUpdate()
    {

        if(movement != Vector2.zero && _isDead == false )
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking Right 1"))
        {
            _isAttacking = true;
        }
        else
        {
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
                _rigidbody.velocity = Vector2.zero;
            }

            if (_lifeGained)
            {
                _rigidbody.velocity = Vector2.zero;
            }

            _rigidbody.velocity = movement * movementSpeed * BASE_SPEED;
        }

        else{
            _rigidbody.velocity = Vector2.zero;
        }
    }

    public void Attack()
    {
        weapon.GetComponent<Weapon>().Attack();
    }

    public void TakeDamage(float damage)
    {

        if(_isInvencible == false)
        {

            animator.SetTrigger("hit");
            currentHealth.RuntimeValue -= damage;
            playerHealthSignal.RaiseSignal();
            StartCoroutine(Invencible());
            
             
            
        }
    }


    private void Die()
    {
        animator.SetTrigger("die");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().Sleep();
    }

    public void Fall()
    {
        animator.SetTrigger("fall");
        
    }

    public void GainHealth(float life)
    {
        if (currentHealth.RuntimeValue + life <= 10)
        {
            currentHealth.RuntimeValue += life;
            playerHealthSignal.RaiseSignal();
        }
        else if(currentHealth.RuntimeValue + life > 10)
        {
            currentHealth.RuntimeValue = 10;
            playerHealthSignal.RaiseSignal();
        }
        

    }

    private IEnumerator Invencible()
    {
        _isInvencible = true;
        yield return new WaitForSeconds(1f);
        _isInvencible = false;
    }
}