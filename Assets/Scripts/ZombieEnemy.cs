using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieEnemy : EnemyController
{
    private float meleeRange = 8f;
    private int damage;

    void Start()
    {
        AttackRange = 5f;
        MovementSpeed = Random.Range(1.5f, 3f);

        AggroRadius = 10f;
        AttackCooldown = 2f;

    }

    protected override void Attack()
    {
        base.Attack();
        RaycastHit hit;
        Ray meleeRay = new Ray(transform.position, transform.forward);

        damage = Random.Range(10, 19);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * meleeRange;
        Debug.DrawRay(transform.position, forward, Color.red, 1f);

        if (Physics.Raycast(meleeRay, out hit, meleeRange))
        {
            if (hit.collider.tag == "Player")
            {
                HealthManager playerHealth = hit.collider.gameObject.GetComponent<HealthManager>();
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
