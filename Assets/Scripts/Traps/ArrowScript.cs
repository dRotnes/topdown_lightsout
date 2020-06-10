using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float damage = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer  == 9)
        {

            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }


}
