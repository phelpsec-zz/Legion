using UnityEngine;
using System.Collections;

public class SpellsGroundStomp : MonoBehaviour
{

    void Start()
    {
        int damage = 30;
        int radius = 10;

        Collider[] enemyList = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider enemy in enemyList)
        {      
            if (enemy.tag == "Enemy")
            {
                EnemyHealth enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
