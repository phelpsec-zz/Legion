﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WizardCombat : PlayerCombat
{
    void Start()
    {
        spells = new List<Spells>();
        spells.Add(new Spells("Fireball", true, 12, 0, ""));
        spells.Add(new Spells("Blink", false, 2, 0, "Target"));
    }
}
