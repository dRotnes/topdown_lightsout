using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject newCamera;
    public GameObject lastCamera;
    public GameObject bounds;
    public bool boundActive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastCamera.SetActive(false);
        newCamera.SetActive(true);
        bounds.SetActive(boundActive);

    }
}
