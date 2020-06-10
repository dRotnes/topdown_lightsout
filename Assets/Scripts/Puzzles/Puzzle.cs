using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Puzzle : MonoBehaviour
{
    public Enemy[] enemies;
    public Door[] doors;
    public Trap[] traps;
    public List<GameObject> objects;
    public PlayableDirector timeline;

    public bool doorCloses;
    public bool trapActivates;
    public bool enemiesActivate;
    public bool activate;
    public void Solved()
    {
        if (objects.Count != 0)
        {
            foreach (GameObject gameobject in objects)
            {

                gameobject.SetActive(activate);

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
            if (enemiesActivate)
            {

                foreach (Enemy enemy in enemies)
                {
                    enemy.gameObject.SetActive(true);
                }
            }
            if (doorCloses)
            {

                foreach (Door door in doors)
                {
                    door.CloseDoor();
                }
            }
            if(trapActivates){
                foreach(Trap trap in traps)
                {
                    trap.gameObject.SetActive(true);
                }
            }
        }
    }
}
