using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int shieldHealth = 30;
    private bool _activeShield;

    public void TakeDamage(int damage)
    {
        shieldHealth -= damage;
    }

    void Update()
    {
        if (Input.GetKey("c"))
        {
            _activeShield = true;
        }
        else if (Input.GetKeyUp("c"))
        {
            _activeShield = false;
        }
    }   
    
    public bool ActiveShield()
    {
        return _activeShield;
    }
}
