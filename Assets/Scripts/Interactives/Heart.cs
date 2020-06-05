using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int livesAdded = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            collision.GetComponent<PlayerController>().GainHealth(livesAdded);
            Destroy(gameObject);
        }
    }
}
