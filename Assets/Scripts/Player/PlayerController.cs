using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Atributes")]
    public float BASE_SPEED= 1f;

    private int _idleType;
    private bool _isAttacking;
    private int _selectedAttack = 0;

    [Space]
    [Header("Statistics")]
    public Vector2 movement;
    public float movementSpeed;

    public int[] attacks;

    [Space]
    [Header("References")]

    public Rigidbody2D rigidbody;
    public Animator animator;

    [Space]
    [Header("Prefabs")]

    public GameObject projectilePrefab;

    // Update is called once per frame

    private void Start()
    {
        Cursor.visible = false;
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

    }

    void GetInputs()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movement.magnitude, 0.0f, 1.0f);
        movement.Normalize();
        AttackSelection();

        if(Input.GetButtonDown("Fire1")) {
            _isAttacking = true;
            
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

        if (_isAttacking == true)
        {
            movement = Vector2.zero;
            animator.SetInteger("selectedAttack", _selectedAttack);
            animator.SetTrigger("attack");
        }

        _isAttacking = false;


    }
    private void FixedUpdate()
    {
        rigidbody.velocity = movement * movementSpeed * BASE_SPEED;

    }

    void AttackSelection()
    {
        foreach(var i in attacks)
        {

            if (Input.GetKeyDown(KeyCode.Alpha0 + i + 1)) { 
        
                _selectedAttack = i;
            }
        }
    }

}