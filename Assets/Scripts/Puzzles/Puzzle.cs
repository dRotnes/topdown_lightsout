using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Puzzle : MonoBehaviour
{
    public Enemy[] enemies;
    public Door[] doors;
    public List<GameObject> objectsToActivate;
    public PlayableDirector timeline;
    public void Solved()
    {
        if (objectsToActivate.Count != 0)
        {
            foreach (GameObject gameobject in objectsToActivate)
            {

                gameobject.SetActive(true);

            }
            if (timeline)
                timeline.Play();

        }
        foreach (Door door in doors)
        {
            door.OpenDoor();
        }

        if (timeline)
        {
            timeline.Play();
        }
        this.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.gameObject.SetActive(true);
            }
            foreach (Door door in doors)
            {
                door.CloseDoor();
            }
        }
    }
}
