using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainer;
    public float life;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth.RuntimeValue = heartContainer.RuntimeValue * 2;
            powerUpSignal.RaiseSignal();
            Destroy(gameObject);
        }
    }
}
