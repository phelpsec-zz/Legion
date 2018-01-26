using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarbarianCombat : PlayerCombat
{
    private float meleeHitDistance = 6;
    private float damage;

    void Start()
    {

    }

    protected override void Attack()
    {
        RaycastHit hit;
        Ray meleeRay = new Ray(transform.position, transform.forward);

        damage = Random.Range(30, 51);
        float generateResource = 10;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * meleeHitDistance;
        Debug.DrawRay(transform.position, forward, Color.red, 1f);

        if (Physics.Raycast(meleeRay, out hit, meleeHitDistance))
        {
            if (hit.collider.tag == "Enemy")
            {
                EnemyHealth enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);

                PlayerResource resource = GetComponent<PlayerResource>();
                resource.GenerateResourceOnHitDealt(generateResource);

            }
        }
    }
}
