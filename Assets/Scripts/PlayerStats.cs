using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    protected int BaseStrength { get; set; }
    protected int BaseDexterity { get; set; }
    protected int BaseIntellect { get; set; }
    protected int BaseVitality { get; set; }

    public int BaseHealth { get { return BaseVitality * 5; } }
    public float BaseHealthRegenRate { get { return BaseVitality / 15; } }
}
