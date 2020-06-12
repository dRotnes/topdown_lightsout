using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Vector2 distance = sr.gameObject.transform.position  - collision.gameObject.transform.position;
            if(distance.y < 0)
            {
                sr.sortingLayerName= "Front Interactables";
            }
            else
            {
                sr.sortingLayerName = "Foreground";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            playerInRange = false;
        }
    }
}
