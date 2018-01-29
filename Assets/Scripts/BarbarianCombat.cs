using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarbarianCombat : PlayerCombat
{
    private float meleeHitDistance = 6;
    private float damage;

    private GameObject activeSpell;
    
    private GameObject spellsBashPrefab;
    private GameObject spellsFireballPrefab;

    protected override void Awake()
    {
        base.Awake();
        spellsBashPrefab = (Resources.Load("Prefabs/Bash")) as GameObject;
        spellsFireballPrefab = (Resources.Load("Prefabs/Fireball")) as GameObject;
    }

    protected override void Attack()
    {
        //GetActiveSpell();

        //TODO: Get the spell from the Active Skill slot and instantiate it.
        Instantiate(spellsBashPrefab, spellSpawnLocation.position, spellSpawnLocation.rotation);
    }

    //private GameObject GetActiveSpell()
    //{
    //    return activeSpell;
    //}
}
