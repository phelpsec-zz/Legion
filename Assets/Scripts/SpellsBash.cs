using UnityEngine;
using System.Collections;

public class SpellsBash : MonoBehaviour
{

    void Start()
    {        
        //TODO: Get PlayerStats and calculate what the damage should be.
        int damage = Random.Range(15, 21);
        int range = 6;
        int generateResourceOnHit = 8;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, range);

        //TODO: Remove DrawRay - this is to show the range in the inspector during live gameplay.
        Debug.DrawRay(transform.position, transform.forward * range, Color.red, 0.25f);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.tag == "Enemy")
            {
                EnemyHealth enemyHealth = hits[i].collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                PlayerResource playerResource = player.GetComponent<PlayerResource>();
                playerResource.GenerateResourceOnHitDealt(generateResourceOnHit);
            }
        }

        Destroy(gameObject);
    }
}
