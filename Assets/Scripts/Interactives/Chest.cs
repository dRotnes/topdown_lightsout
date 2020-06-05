using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    private bool _canOpen;
    private bool _isOpen;

    public GameObject objectToAppear;

    private void Update()
    {
        if(_canOpen && Input.GetKeyDown("space") &&!_isOpen)
        {
            Open();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canOpen = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _canOpen = false;
    }
    private void Open()
    {
        animator.SetTrigger("open");
        Instantiate(objectToAppear, transform.position, Quaternion.identity);
        _isOpen = true;
    }
}
