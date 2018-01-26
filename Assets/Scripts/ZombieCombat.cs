using UnityEngine;
using System.Collections;

public class ZombieCombat : EnemyCombat
{
    private float meleeHitDistance = 6;
    private RaycastHit hit;
    private Ray meleeRay;

    void Start()
    {
        RangeToAttack = 5;
        NextAttackTimer = 2;

        AggroDistance = 15;
        UnAggroTimer = Random.Range(4, 6);
    }

    public override void Attack()
    {
        Damage = Random.Range(10, 19);
        meleeRay = new Ray(transform.position, transform.forward);       

        if (Physics.Raycast(meleeRay, out hit, meleeHitDistance))
        {
            if (hit.collider.tag == "Player")
            {
                PlayerHealth playerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(Damage);
            }
        }
    }
}
