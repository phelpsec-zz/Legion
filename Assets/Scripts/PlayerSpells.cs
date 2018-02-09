using UnityEngine;
using System.Collections;

public class PlayerSpells : MonoBehaviour
{
    public string SpellName { get; set; }
    public bool IsActive { get; set; }
    public string TypeOfSpell { get; set; }

    public int ResourceCost { get; set; }
    public int ResourceGenerate { get; set; }

    public PlayerSpells(string spellName, bool isActive, string typeOfSpell, int resourceCost, int resourceGenerate)
    {
        SpellName = spellName;
        IsActive = isActive;
        TypeOfSpell = typeOfSpell;

        ResourceCost = resourceCost;
        ResourceGenerate = resourceGenerate;
    }
}
