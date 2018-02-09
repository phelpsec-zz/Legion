using UnityEngine;
using System.Collections;

public class SpellsFireball : MonoBehaviour
{
    private int damage;
    private int range;
    private int speed;

    private Vector3 startPosition;  

    void Start()
    {
        //TODO: Get PlayerStats stats and level to calculate damage.
        damage = Random.Range(20, 31);
        range = 40;
        speed = 50;

        startPosition = transform.position;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, startPosition) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
