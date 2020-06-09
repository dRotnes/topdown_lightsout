using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public float activeTime = 3f;
    public float reactivateTime = 2f;
    public float activationRate = 5f;
    public float damageRate = 1.5f;
    public float trapDamage = 10;

    public bool isActive;
    private bool _activateAgain = true;
    private bool _isDamaging;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _animator.SetBool("canActivate", true);
  
    }

    // Update is called once per frame
    void Update()
    {

        if(_activateAgain == false)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    private void LateUpdate()
    {
        _animator.SetBool("canActivate", _activateAgain);
        _animator.SetBool("active", isActive);
    }


    // Applie Damage part
    private IEnumerator Damage(Collider2D player)
    {
        while(_isDamaging == true)
        {

            player.GetComponent<PlayerController>().TakeDamage(trapDamage);
            yield return new WaitForSeconds(damageRate);
        }

    }

    //Activation Part
    private void Activate()
    {
        isActive = true;
        _isDamaging = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            StartCoroutine(Desactivate());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FootCollider"))
        {
            Activate();
            StartCoroutine(Damage(collision.gameObject.transform.parent.gameObject.GetComponent<Collider2D>()));

        }
    }
    private IEnumerator WaitToActivateAgain()
    {
        yield return new WaitForSeconds(reactivateTime);
        _activateAgain = true;
    }
    private IEnumerator Desactivate()
    {
        _isDamaging = false;
        yield return new WaitForSeconds(activeTime);
        isActive = false;
        _activateAgain = false;
        StartCoroutine(WaitToActivateAgain());
    }
}
