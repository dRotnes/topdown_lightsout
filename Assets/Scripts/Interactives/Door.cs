using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key, 
    enemy, 
    button,
    fire
}
public class Door : Interactable
{
    [Header("Variables")]
    public DoorType thisDoorType;
    private bool _isOpen;
    public Animator animator;
    public Inventory playerInventory;
    public Collider2D doorCollider;
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if(playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    OpenDoor();
                }
            }
        }
    }
    public void OpenDoor() {

        _isOpen = true;
        doorCollider.enabled = false;
        animator.SetBool("isOpen", _isOpen);
    }

    public void CloseDoor()
    {
        _isOpen = true;
        doorCollider.enabled = true;
        animator.SetBool("isOpen", _isOpen);
    }

}
