using UnityEngine;
using System.Collections;

public class SpellsFireball : SpellsManager
{
    private Vector3 startPosition;
    private GameObject player;
    private PlayerResource playerResource;

    void Start()
    {
        Damage = Random.Range(20, 31);

        Speed = 60;
        Range = 30;
        ResourceCost = 1;

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
