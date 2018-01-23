using UnityEngine;
using System.Collections;

public class ZombieCombat : EnemyCombat
{
    private float damage;
    private float meleeHitDistance = 6;

    void Start()
    {
        RangeToAttack = 5;
        NextAttackTimer = 2;

        AggroDistance = 15;
        UnAggroTimer = Random.Range(4, 6);
    }


    public override void Attack()
    {
        RaycastHit hit;
        Ray meleeRay = new Ray(transform.position, transform.forward);

        damage = Random.Range(10, 19);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * meleeHitDistance;
        Debug.DrawRay(transform.position, forward, Color.red, 1f);

        if (Physics.Raycast(meleeRay, out hit, meleeHitDistance))
        {
            if (hit.collider.tag == "Player")
            {
                PlayerHealth playerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
