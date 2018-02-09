using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WizardCombat : PlayerCombat
{
    //PlayerSpells (SpellName, IsActive, TypeOfSpell, ResourceCost, ResourceGenerate)

    void Start()
    {
        spells = new List<PlayerSpells>();
        spells.Add(new PlayerSpells("Fireball", true, "", 10, 0));
        spells.Add(new PlayerSpells("Blink", false, "Target", 18, 0));
        spells.Add(new PlayerSpells("Blizzard", false, "Target", 50, 0));
    }
}
