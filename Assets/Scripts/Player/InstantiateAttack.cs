using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAttack : MonoBehaviour
{
    public GameObject attackprefab;
    public Transform firePoint;
    public void Instantiate()
    {
        Instantiate(attackprefab, firePoint.position, firePoint.rotation);
    }
}
