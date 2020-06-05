using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private GameObject _shield;
    private bool _hasShield;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount !=  0  && _hasShield ==false)
        {
            _shield = transform.GetChild(0).gameObject;
            _hasShield = true;
            Debug.Log(_shield.name);
        }

    }
}
