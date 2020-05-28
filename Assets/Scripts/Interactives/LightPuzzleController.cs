using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class LightPuzzleController : MonoBehaviour
{
    public List<FireLighterController> fireLighterList;
    public List<GameObject> objectsToDesactivate;
    public List<GameObject> objectsToActivate;
    private int numberOfFireLighters;
    public PlayableDirector timeline;

    private int numberOfOn = 0;


    private void Start()
    {
        numberOfFireLighters = fireLighterList.Count;
    }
    private void Update()
    {
        if (numberOfOn == numberOfFireLighters)
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
            else if (objectsToDesactivate.Count != 0)
            {
                foreach (GameObject gameobject in objectsToDesactivate)
                {

                    gameobject.SetActive(false);
                }

            }

            if (timeline)
                timeline.Play();

            numberOfFireLighters = 0;

        }

    }
    public void updateNumberOfOn(bool update)
    {

        if (fireLighterList.Count != 0)
        {
            if (update == true)
            {
                numberOfOn += 1;
            }
            else
            {
                numberOfOn -= 1; 
            }
        }
    }
}
