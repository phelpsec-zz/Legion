using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianStats : StatsManager {

    private float health;
    private float healthRegenerationRate;

    void Start() {
        
        BaseStrength = 30f;
        BaseDexterity = 20f;
        BaseIntellect = 10f;
        BaseVitality = 40f;

        health = GetHealth();
        healthRegenerationRate = GetHealthRegenerationRate();

        GetComponent<HealthManager>().CurrentHealth = health;
        GetComponent<HealthManager>().MaxHealth = health;     

        //Debug.Log("Health: " + health);
        //Debug.Log("Regeneration: " + healthRegenerationRate + " per second");
    }

    void Update() {

    }
}
