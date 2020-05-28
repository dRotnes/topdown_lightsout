using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;

public class FireLighterController : MonoBehaviour
{
    public LightPuzzleController puzzleController;
    public GameObject fireLighterToDesactivate;

    private Animator _animator;
    private bool _isOn;
    private bool _isActivatable;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_isOn == false && _isActivatable==true && Input.GetKey("c"))
        {
            _animator.SetTrigger("activate");
            if (fireLighterToDesactivate)
                DesactivateOther();

            puzzleController.updateNumberOfOn(true);
            _isOn = true;
            _isActivatable = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
            _isActivatable = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
            _isActivatable = false;
    }

    private void DesactivateOther()
    {
        fireLighterToDesactivate.GetComponent<FireLighterController>().Desactivate();
    }

    public void Desactivate()
    {
        if(_isOn == true)
        {

            puzzleController.updateNumberOfOn(false);
            _isOn = false;
            _animator.SetTrigger("desactivate");
        }
    }

    public bool IsActivated()
    {
        return _isOn;
    }
}
