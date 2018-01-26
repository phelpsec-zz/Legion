using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool IsInCombat { get; set; }

    private float timeToNextAttack;
    private float globalCooldownTimer = 0.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)))
        {
            if (Time.time >= timeToNextAttack)
            {
                //TODO: Implement specific spell cooldowns into the timeToNextAttack formula.
                timeToNextAttack = Time.time + globalCooldownTimer;
                Attack();
            }                 
        }
    }

    //TODO: Get the active spell from the UI Active Spell Button (Implement this on each class's Attack method).
    protected virtual void Attack()
    {
        
    }
}
