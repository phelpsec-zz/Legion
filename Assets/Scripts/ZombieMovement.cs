using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieMovement : EnemyMovement
{
    void Start()
    {        
        MovementSpeed = Random.Range(1, 3);
    }
}
