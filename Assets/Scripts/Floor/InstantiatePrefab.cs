using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab: MonoBehaviour
{
    public GameObject prefab;
    public void Instantiate()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
