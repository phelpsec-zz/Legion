using UnityEngine;
using System.Collections;

public class SpellsFireball : Spells
{
    private Vector3 startPosition;

    private SpellsFireball(string spellName, bool isActive, int resourceCost, int resourceGenerate) 
        : base(spellName, isActive, resourceCost, resourceGenerate) { }

    void Start()
    {
        Damage = Random.Range(20, 31);
        Speed = 50;
        Range = 40;

        startPosition = transform.position;
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, startPosition) >= Range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
