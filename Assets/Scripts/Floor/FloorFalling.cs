using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFalling : MonoBehaviour
{
    private Animator _animator;
    private bool _readyToFall;
    private bool _isHole;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("hole"))
        {

            _isHole = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isHole == true)
        { 
            collision.GetComponent<PlayerController>().Fall();
        }
        else
        {
            _readyToFall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_readyToFall == true)
        {
            _animator.SetTrigger("fall");
        }
    }
}
