using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int projectileDamage = 1;
    public float damageRange = 0.8f;
    public LayerMask playerLayer;

    private Transform _player;
    private Vector2 _target;
    private Rigidbody2D _rigidbody;


    private Animator _animator;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _target = new Vector2(_player.position.x, _player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, speed * Time.deltaTime);

        Collider2D[] hitArray = Physics2D.OverlapCircleAll(transform.position, damageRange, playerLayer);

        Debug.Log(hitArray);
        foreach (Collider2D collider in hitArray)
        {
            /*PlayerController player = collider.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(1, "projectile");*/
        }

        if (transform.position.x == _target.x && transform.position.y == _target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (transform != null)
        {

            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
    }
}
