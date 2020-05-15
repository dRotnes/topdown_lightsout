using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 1f;
    public Rigidbody2D rigidbody;
    private float projectileForce = 2f;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }
    void Start()
    {
        rigidbody.AddForce(transform.right * projectileForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider);
        _animator.SetTrigger("impact");
    }
}
