using UnityEngine;
using System.Collections;

public class SpellsBlizzard : MonoBehaviour
{
    private int damage;
    private int range = 15;
    private int duration = 3;

    private float timeToDestroy;

    void Start()
    {
        damage = Random.Range(1, 26);
        Debug.Log("blizzard dmg = " + damage);

        timeToDestroy = Time.time + duration;       
    }
    
    void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range);

        if (Time.time > timeToDestroy)
        {
            Destroy(gameObject);
        } 

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
