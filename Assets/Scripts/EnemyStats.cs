using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    private float baseVitality;
    protected float BaseVitality { get { return baseVitality; } set { baseVitality = value; } }

    private float experienceAmount;
    public float ExperienceAmount { get { return experienceAmount; } set { experienceAmount = value; } }

    public float Level { get; set; }

    public float BaseHealth { get { return baseVitality * 5; } }
}
