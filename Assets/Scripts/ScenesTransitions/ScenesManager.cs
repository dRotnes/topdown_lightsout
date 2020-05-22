using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public GameObject sceneTransition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        sceneTransition.GetComponent<SceneTransition>().LoadNextScene();

        
    }

}
