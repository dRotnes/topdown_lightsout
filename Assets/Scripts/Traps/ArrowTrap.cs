using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : Trap
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public Vector2 arrowForce;
    
    private bool _shoot;
    private float _time = 0;

    void Update()
    {
        if(_shoot == true)
        {
            if(_time < Time.time)
            {
                
                GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D arrow_rb = arrow.GetComponent<Rigidbody2D>();
                arrow_rb.velocity= arrowForce;
                Destroy(arrow, activeTime);
                

                _time = Time.time + activationRate; 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
           
            _shoot = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            _shoot = false;

        }
    }

}
