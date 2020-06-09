using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class LightPuzzleController : Puzzle
{
    public List<FireLighterController> fireLighterList;
    private int numberOfOn = 0;


    private void Update()
    {
        if (numberOfOn == fireLighterList.Count)
        {
            Solved();
            this.enabled = false;
        }
    }
    public void updateNumberOfOn()
    {
        numberOfOn = 0;
        foreach (FireLighterController fireLighter in fireLighterList)
        {
            if (fireLighter.IsActivated() == true)
            {
                numberOfOn++;
            }
        }
    }
}
