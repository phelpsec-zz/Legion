using UnityEngine;
using System.Collections;

public class ZombieStats : EnemyStats
{
    void Start()
    {
        BaseVitality = 10;

        Level = 1;
        ExperienceAmount = 35;
    }
}
