using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieMovement : EnemyMovement
{
    void Start()
    {        
        MovementSpeed = Random.Range(1, 3);
        //AggroDistance = 15;
        //UnAggroTimer = Random.Range(4, 6);
    }
}
