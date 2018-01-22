using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStats : StatsManager {

    private float health;
    private float healthRegenerationRate;

    void Start() {

        BaseStrength = 10f;
        BaseDexterity = 15f;
        BaseIntellect = 35f;
        BaseVitality = 30f;

        health = GetHealth();
        healthRegenerationRate = GetHealthRegenerationRate();

        gameObject.GetComponent<HealthManager>().CurrentHealth = health;
        gameObject.GetComponent<HealthManager>().MaxHealth = health;

        //Debug.Log("Health: " + health);
        //Debug.Log("Regeneration: " + healthRegenerationRate + " per second");
    }

    void Update() {

    }
}
