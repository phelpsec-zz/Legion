using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarbarianCombat : PlayerCombat
{  

    protected override void Awake()
    {
        base.Awake();

        spells = new List<Spells>();
        spells.Add(new Spells("Bash", false, 0, 0));
        spells.Add(new Spells("Fireball", true, 6, 0));
        spells.Add(new Spells("Ground Stomp", false, 20, 0));
    }

    protected override void Attack()
    {
        //TODO: Get the spell from the Active Skill slot and instantiate it.
        GetActiveSpell();

        //TODO: Check to make sure the spell we instantiate doesn't cost more resource than the player has.

        if (playerResource.CurrentResource >= activeSpell.ResourceCost)
        {
            Instantiate(activeSpellPrefab, spellSpawnLocation.position, spellSpawnLocation.rotation);

            playerResource.GenerateResourceOnSpellCast(activeSpell.ResourceGenerate);
            playerResource.SpendResourceOnSpellCast(activeSpell.ResourceCost);
        }
    }

    private GameObject GetActiveSpell()
    {

        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].IsActive)
            {
                activeSpellName = spells[i].SpellName;
                activeSpell = spells[i];
            }
        }

        activeSpellPrefab = Resources.Load("Prefabs/" + activeSpellName) as GameObject;
        return activeSpellPrefab;
    }
}
