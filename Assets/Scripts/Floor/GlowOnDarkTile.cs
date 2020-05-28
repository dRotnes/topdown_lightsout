
using UnityEngine;

public class GlowOnDarkTile : MonoBehaviour
{
    private GameObject fireBall;
    private Animator _animator;
    private bool _isHole = true;

    public bool isAlwaysHole = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        fireBall = GameObject.Find("Fireball");
    }

    private void Start()
    {
        _animator.SetBool("hole", _isHole);
    }

    void Update()
    {
        if(isAlwaysHole == false)
        {
            if(fireBall.activeSelf == false)
            {
                _isHole=false;
            }
            else if(fireBall.activeSelf == true)
            {
                _isHole = true;
            }
        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("hole", _isHole);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (_isHole == true)
            {
                collision.GetComponent<PlayerController>().Fall();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 9)
        {
            if (_isHole == true)
            {
                collision.GetComponent<PlayerController>().Fall();
            }
        }
    }

}
