using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManJacob : MonoBehaviour
{
    public List<DialogTrigger> dialogs;
    public GameObject forceCamp; 
    private void Update()
    {
        if(forceCamp.activeSelf == true)
        {
            dialogs[0].enabled = true;
            dialogs[1].enabled = false;
        }
        else{
            dialogs[1].enabled = true;
            dialogs[0].enabled = false;
        }
    }
}
