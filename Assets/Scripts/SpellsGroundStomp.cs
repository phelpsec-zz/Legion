using UnityEngine;
using System.Collections;

public class SpellsGroundStomp : Spells
{
    private SpellsGroundStomp(string spellName, bool isActive, int resourceCost, int resourceGenerate, string typeOfSpell) 
        : base(spellName, isActive, resourceCost, resourceGenerate, typeOfSpell) { }

    void Start()
    {
        Damage = 30;
        Range = 10;

        Collider[] enemyList = Physics.OverlapSphere(transform.position, Range);

        foreach (Collider enemy in enemyList)
        {      
            if (enemy.tag == "Enemy")
            {
                EnemyHealth enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(Damage);
            }
        }

        Destroy(gameObject);
    }
}
