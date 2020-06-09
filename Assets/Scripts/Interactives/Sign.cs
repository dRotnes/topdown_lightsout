using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    public DialogTrigger dialog;
    public bool multiple;

    
    void Update()
    {
        if (playerInRange)
        {
           
            if (!multiple)
            {
                    
                dialog.TriggerDialog();
                    
            }
            
        }
        else
        {
            
            dialog.EndDialog();
            
        }
    }
}
