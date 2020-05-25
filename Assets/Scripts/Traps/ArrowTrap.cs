using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float timeBetweenShots = 1f;
    public Transform firePoint;
    public Vector2 arrowForce;
    public float arrowLifetime = 2f;
    
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
                Destroy(arrow, arrowLifetime);
                

                _time = Time.time + timeBetweenShots; 
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

    /* private IEnumerator Shoot()
     {
         int currentActivation = 0;
         while (currentActivation < 1)
         {

             GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
             Rigidbody2D arrow_rb = arrow.GetComponent<Rigidbody2D>();
             arrow_rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
             Destroy(arrow, arrowLifetime);
             currentActivation++;
         }
         yield return new WaitForSeconds(timeBetweenShots);
         StartCoroutine(Shoot());
     }*/

}
