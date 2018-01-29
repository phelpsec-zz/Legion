using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianStats : PlayerStats
{
    private UIController uiController;

    private void Awake()
    {
        uiController = GameObject.Find("UI").GetComponent<UIController>();
    }

    void Start()
    {
        BaseStrength = 30;
        BaseDexterity = 20;
        BaseIntellect = 10;
        BaseVitality = 40;

        
    }
}
