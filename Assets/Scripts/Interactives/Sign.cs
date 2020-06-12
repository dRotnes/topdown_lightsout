using UnityEngine;

public class Sign : Interactable
{
    public DialogTrigger dialog;
    private bool canDesactivate;

    private void Update()
    {
        if (playerInRange)
        {
            canDesactivate = true;
            if (Input.GetKeyDown(KeyCode.Space) && dialog.ReturnState() == false)
            {
                dialog.TriggerDialog();
                Debug.Log(canDesactivate);
            }

        }
        else
        {
            if (dialog.ReturnState() == true && canDesactivate == true)
            {
                dialog.EndDialog();
                canDesactivate = false;
                Debug.Log(canDesactivate);
            }
        }
    }
  
}
