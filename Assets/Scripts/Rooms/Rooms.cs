using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public Enemy[] enemies;
    public Door[] doors;
    public Puzzle puzzle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.gameObject.SetActive(true);
            }
            foreach(Door door in doors)
            {
                door.CloseDoor();
            }
        }
    }
}
