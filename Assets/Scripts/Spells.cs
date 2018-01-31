using UnityEngine;
using System.Collections;

public class Spells : MonoBehaviour
{
    protected int Damage { get; set; }
    protected int Range { get; set; }
    protected int Speed { get; set; }
    protected int Duration { get; set; }
    protected int Heal { get; set; }

    public string SpellName { get; set; }
    public bool IsActive { get; set; }
    public int ResourceCost { get; set; }
    public int ResourceGenerate { get; set; }
    public int Cooldown { get; set; }

    public Spells(string spellName, bool isActive, int resourceCost, int resourceGenerate)
    {
        this.SpellName = spellName;
        this.IsActive = isActive;
        this.ResourceCost = resourceCost;
        this.ResourceGenerate = resourceGenerate;
    }

}
