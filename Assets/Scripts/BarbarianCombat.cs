using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarbarianCombat : PlayerCombat
{  
    void Start()
    {
        spells = new List<Spells>();
        spells.Add(new Spells("Bash", true, 0, 0));
        spells.Add(new Spells("Ground Stomp", false, 10, 0));
    }
}
