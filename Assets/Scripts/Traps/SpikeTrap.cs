using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public float activeTime = 3f;
    private float _startTime = 0f;

    public float activationRate = 5f;
    private float nextActivationTime = 0f;

    public float damageRange = 0.2f;
    public LayerMask playerLayer;

    private bool _isActivated;
    private bool _activateAgain;

    public int spikeDamage = 1;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _animator.SetBool("canActivate", true);
        _activateAgain = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(_isActivated == false)
        { 
            _startTime += Time.deltaTime;

        }
        if(_activateAgain == false)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if(_isActivated == true)
        {
            Collider2D[] hitArray = Physics2D.OverlapCircleAll(transform.position, damageRange, playerLayer);

            foreach (Collider2D player in hitArray)
            {
                StartCoroutine(WaitToDamageAgain(player));
            }
        }

    }

    private void LateUpdate()
    {
        _animator.SetBool("activated", _isActivated);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        _isActivated = true;
        _animator.SetBool("activated", true);
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        _isActivated = true;
        _animator.SetBool("activated", true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Desactivate());
    }

    private void OnDrawGizmosSelected()
    {
        if (transform != null)
        {

            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
    }

    private IEnumerator WaitToDamageAgain(Collider2D player)
    {
        player.GetComponent<PlayerController>().TakeDamage(spikeDamage);
        yield return new WaitForSeconds(5f);

    }
    private IEnumerator WaitToActivateAgain()
    {
        yield return new WaitForSeconds(2f);
        _animator.SetBool("canActivate", true);
        _activateAgain = true;
    }
    private IEnumerator Desactivate()
    {
        yield return new WaitForSeconds(2f);
        _isActivated = false;
        _animator.SetBool("canActivate", false);
        _activateAgain = false;
        StartCoroutine(WaitToActivateAgain());
    }
}
