using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public bool isTyped;
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog, isTyped);
    }
}
