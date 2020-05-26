using UnityEngine;
using UnityEngine.Playables;

public class FireLighterController : MonoBehaviour
{

    public GameObject objectToDesactivate;
    public GameObject objectToActivate;

    public PlayableDirector timeline;

    private Animator _animator;
    private bool _isOn;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (Input.GetKeyDown("c") && _isOn == false)
        {
            _animator.SetTrigger("activate");
            _isOn = true;
            if (objectToActivate)
            {
                objectToActivate.SetActive(true);
                
                if(timeline)
                    timeline.Play();
            }
            else if (objectToDesactivate)
            {
                objectToDesactivate.SetActive(false);
                if (timeline)
                    timeline.Play();
            }

        }
    }

    public void Desactivate()
    {
        _animator.SetTrigger("desactivate");
        _isOn = false;
    }

    public bool IsActivated()
    {
        return _isOn;
    }
}
