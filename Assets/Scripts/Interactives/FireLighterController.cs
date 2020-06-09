using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;

public class FireLighterController : Interactable
{
    public GameObject fireLighterToDesactivate;
    public SignalSend fireOnSignal;
    public Animator animator;

    public bool isOn;

    private void Update()
    {
        if (isOn == false && playerInRange && Input.GetKey("space"))
        {
            animator.SetTrigger("activate");
            if (fireLighterToDesactivate)
            {
                DesactivateOther();
            }

            isOn = true;

            fireOnSignal.RaiseSignal();
        }
    }

    private void DesactivateOther()
    {
        fireLighterToDesactivate.GetComponent<FireLighterController>().Desactivate();
    }

    public void Desactivate()
    {
        if(isOn == true)
        {
            isOn = false;
            animator.SetTrigger("desactivate");
            
        }
    }

    public bool IsActivated()
    {
        return isOn;
    }
}
