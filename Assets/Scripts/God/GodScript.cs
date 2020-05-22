using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodScript : MonoBehaviour
{
    public GameObject dialog;
    private void Start()
    {
        dialog.GetComponent<DialogTrigger>().TriggerDialog();
    }

}
