using UnityEngine;
using System.Collections;

public class ZombieStats : EnemyStats
{
    void Start()
    {
        BaseVitality = 10;
        ExperienceAmount = 35;
        Level = 1;
    }
}
