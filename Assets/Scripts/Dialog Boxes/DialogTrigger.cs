using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public bool isTyped;
    public bool playOnAwake;
    private bool _isTriggerable;
    private bool _isActive;
    private void Start()
    {
        if (playOnAwake)
        {
            TriggerDialog();

        }
    }

    private void Update()
    {
        if (!playOnAwake && _isTriggerable && !_isActive)
        {
            
            TriggerDialog();
            _isActive = true;
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            
            _isTriggerable = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        _isTriggerable = false;
        FindObjectOfType<DialogManager>().EndDialog();
        _isActive = false;

    }
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog, isTyped);
    }
}
