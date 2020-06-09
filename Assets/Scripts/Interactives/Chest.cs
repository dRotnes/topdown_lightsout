using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private bool _canOpen;
    private bool _isOpen;

    public Inventory playerInventory;
    public Animator animator;
    public SignalSend raiseItem;
    public Item item;

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown("space"))
        {
            if (!_isOpen)
            {

                Open();
            }
            else
            {
                chestIsOpen();
            }
        }
    }
    private void Open()
    {
        animator.SetTrigger("open");
        playerInventory.currentItem = item;
        playerInventory.AddItem(playerInventory.currentItem);
        raiseItem.RaiseSignal();
        _isOpen = true;
    }
    private void chestIsOpen()
    {
        raiseItem.RaiseSignal();
    }
}
