using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour {

    private float baseStrength;
    private float baseDexterity;
    private float baseIntellect;
    private float baseVitality;

    private float attackRange;
    private float movementSpeed;

    protected float BaseStrength { get { return baseStrength; } set { baseStrength = value; } }
    protected float BaseDexterity { get { return baseDexterity; } set { baseDexterity = value; } }
    protected float BaseIntellect { get { return baseIntellect; } set { baseIntellect = value; } }
    protected float BaseVitality { get { return baseVitality; } set { baseVitality = value; } }

    protected float AttackRange { get { return attackRange; } set { attackRange = value; } }
    protected float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }

    public float GetHealth() { return baseVitality * 5f; }
    public float GetHealthRegenerationRate() { return baseVitality / 100f; }

    void Awake() {

    }

    void Start() {

    }

    void Update() {

    }
}
