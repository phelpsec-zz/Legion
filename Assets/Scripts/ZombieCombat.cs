using UnityEngine;
using System.Collections;

public class ZombieCombat : EnemyCombat
{

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

        int meleeHitDistance = 6;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, meleeHitDistance); ;       

        Debug.DrawRay(transform.position, transform.forward * meleeHitDistance, Color.red, 0.25f);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.tag == "Player")
            {
                PlayerHealth playerHealth = hits[i].collider.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(Damage);
            }
        }
    }
}
