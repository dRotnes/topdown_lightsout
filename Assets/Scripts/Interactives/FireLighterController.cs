using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireLighterController : MonoBehaviour
{
    
    public GameObject fireLighterOnPrefab;
    private bool _isOn;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (Input.GetButtonDown("Fire2"))
        {
            if(_isOn == false)
            { 
                Instantiate(fireLighterOnPrefab, transform.position, Quaternion.identity);
                _isOn = true;
            }
        }
    }
}
