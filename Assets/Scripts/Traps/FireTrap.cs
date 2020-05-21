using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    //Times it will be active
    public float activeRate = 0.5f;
    public int activeTimes = 3;

    // Times it will be activated 
    public float activationRate = 3f;
    public int activatedTimes = 3;

    public int fireDamage = 3;

    private Animator _animator;
    private Collider2D _player;

    private void Start()
    {

        _animator = GetComponent<Animator>();
        StartCoroutine(Active());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9) 
            _player = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _player = null;
    }
    private IEnumerator Active()
    {
        
        int currentActivation = 0;
        while(currentActivation < activeTimes)
        {   
            _animator.SetTrigger("active");
            if(_player != null)
            {
                _player.GetComponent<PlayerController>().TakeDamage();
            }
            yield return new WaitForSeconds(activeRate);
            
            currentActivation++;
        }
        yield return new WaitForSeconds(activationRate);
        StartCoroutine(Active());

    }
   
}

