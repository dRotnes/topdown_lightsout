using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger: MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDesactivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectsToActivate.Count!=0)
        {
            foreach (GameObject gameobject in objectsToActivate)
            {
                gameobject.SetActive(true);
            }
        }
        else if (objectsToDesactivate.Count != 0)
        {
            foreach (GameObject gameobject in objectsToDesactivate)
            {
                gameobject.SetActive(false);
            }
        }
    }
}
