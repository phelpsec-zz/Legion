using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    protected float BaseVitality { get; set; }
    public float BaseHealth { get { return BaseVitality * 5; } }

    public float Level { get; set; }
    public float ExperienceAmount { get; set; }
}
