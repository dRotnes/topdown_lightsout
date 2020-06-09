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

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog, isTyped);
    }
    public void EndDialog()
    {
        FindObjectOfType<DialogManager>().EndDialog();

    }

}
