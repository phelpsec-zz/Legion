using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianStats : PlayerStats
{
    private UIDeathScreen uiController;

    private void Awake()
    {
        uiController = GameObject.Find("UI").GetComponent<UIDeathScreen>();
    }

    void Start()
    {
        BaseStrength = 30;
        BaseDexterity = 20;
        BaseIntellect = 10;
        BaseVitality = 40;

        
    }
}
