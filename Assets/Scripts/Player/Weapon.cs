using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject projectile;
    public void Attack()
    {
        Instantiate(projectile, firepoint.position, firepoint.rotation);
    }

    
}
