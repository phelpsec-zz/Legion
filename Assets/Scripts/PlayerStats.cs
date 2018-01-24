﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float baseStrength;
    private float baseDexterity;
    private float baseIntellect;
    private float baseVitality;

    protected float BaseStrength { get { return baseStrength; } set { baseStrength = value; } }
    protected float BaseDexterity { get { return baseDexterity; } set { baseDexterity = value; } }
    protected float BaseIntellect { get { return baseIntellect; } set { baseIntellect = value; } }
    public float BaseVitality { get { return baseVitality; } set { baseVitality = value; } }

    public float BaseHealth { get { return baseVitality * 5; } }
    public float BaseHealthRegenRate { get { return baseVitality / 15; } }


    //TODO: Move to PlayerCombat.
    private float attackRange;
    protected float AttackRange { get { return attackRange; } set { attackRange = value; } }

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
