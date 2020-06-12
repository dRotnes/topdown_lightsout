using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public bool isTyped;
    public bool playOnAwake;

    private void Start()
    {
        if (playOnAwake)
        {
            TriggerDialog();

        }
    }
    public void TriggerDialog()
    {
        
        FindObjectOfType<DialogManager>().StartDialog(dialog, isTyped);
    }

    public void EndDialog()
    {
        FindObjectOfType<DialogManager>().EndDialog();
    }

    public bool ReturnState()
    {
        bool active =  FindObjectOfType<DialogManager>().CurrentState();
        return active;
    }

}
