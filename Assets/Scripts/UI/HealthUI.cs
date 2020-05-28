using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthUI : MonoBehaviour
{ 
    private TextMeshProUGUI healthDisplay;
    private void Awake()
    {
        healthDisplay= GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetHealth(int health)
    {
        healthDisplay.text = health.ToString() + " x";
    }
}
