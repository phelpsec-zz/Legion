using UnityEngine;
using System.Collections;

public class SpellsBlizzard : MonoBehaviour
{
    private int damage;
    private int radius = 10;
    private int duration = 3;
    private float timeToDestroy;

    void Start()
    {
        damage = Random.Range(15, 26);
        timeToDestroy = Time.time + duration;       
    }
    
    void Update()
    { 
        if (Time.time > timeToDestroy)
        {
            Destroy(gameObject);
        }

        Collider[] enemies = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider enemy in enemies)
        {
            if (enemy && enemy.tag == "Enemy")
            {
                EnemyHealth enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeOverTimeDamage(damage);
            }
        }      
    }
}
