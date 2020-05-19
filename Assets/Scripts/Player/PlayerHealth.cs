using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 10;
    public int currentHealth;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHealth = totalHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            TakeDamage(1);
        }
    }
    private void TakeDamage(int damageTaken) {
        currentHealth -= damageTaken;
        _animator.SetTrigger("hit");
    }
}
