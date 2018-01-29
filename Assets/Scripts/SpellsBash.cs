using UnityEngine;
using System.Collections;

public class SpellsBash : MonoBehaviour
{
    private GameObject player;
    private PlayerResource playerResource;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerResource = player.GetComponent<PlayerResource>();
    }

    void Start()
    {
        RaycastHit[] hits;
        int damage = Random.Range(30, 51);
        int generateResource = 8;
        int meleeHitDistance = 6;

        Debug.DrawRay(transform.position, transform.forward * meleeHitDistance, Color.red, 0.25f);

        hits = Physics.RaycastAll(transform.position, transform.forward, meleeHitDistance);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.tag == "Enemy")
            {
                EnemyHealth enemyHealth = hits[i].collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);

                playerResource.GenerateResourceOnHitDealt(generateResource);
            }
        }

        Destroy(gameObject);
    }
}
