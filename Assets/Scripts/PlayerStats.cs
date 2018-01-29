using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    protected int BaseStrength { get; set; }
    protected int BaseDexterity { get; set; }
    protected int BaseIntellect { get; set; }
    protected int BaseVitality { get; set; }

    public int BaseHealth { get { return BaseVitality * 5; } }
    public float BaseHealthRegenRate { get { return BaseVitality / 15; } }

    public Image CharacterPortrait { get; set; }
}
