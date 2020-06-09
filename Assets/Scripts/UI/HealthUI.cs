﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainer;
    public FloatValue playerHealth;

    private void Start()
    {
        InitHearts();
    }
    public void InitHearts()
    {
        for (int i = 0; i < heartContainer.RuntimeValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite =fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerHealth.RuntimeValue / 2;

        for (int i = 0; i < heartContainer.RuntimeValue; i++)
        {
            if (i <= tempHealth-1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i > tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfHeart;
            }
        }
    }
}
