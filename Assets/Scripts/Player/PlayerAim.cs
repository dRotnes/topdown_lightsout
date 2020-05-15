using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Vector3 _target;

    public GameObject crosshair;

    public Camera cam;


    void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(_target.x, _target.y);

    }

    
}
