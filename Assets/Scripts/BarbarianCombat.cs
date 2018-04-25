using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarbarianCombat : PlayerCombat
{  
    //PlayerSpells (SpellName, IsActive, TypeOfSpell, ResourceCost, ResourceGenerate)

    void Start()
    {
        spells = new List<PlayerSpells>();
        spells.Add(new PlayerSpells("Bash", true, "", 0, 0));
        spells.Add(new PlayerSpells("Ground Stomp", false, "", 25, 0));
        //spells.Add(new PlayerSpells("Leap", true, "Target", 0, 0));
    }
}
