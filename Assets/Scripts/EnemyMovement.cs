using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    protected float MovementSpeed { get; set; }

    private float timeToWander;
    private float timeToNextAttack;

    private Vector3 destinationPosition;
    private Vector3 stopPosition;

    private GameObject player;
    private PlayerHealth playerHealth;

    private EnemyCombat combat;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        combat = GetComponent<EnemyCombat>();
    }

    void Update()
    {             
        if (combat.IsAggrovated)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > combat.RangeToAttack)
            {
                destinationPosition = player.transform.position;
            }
            else
            {               
                destinationPosition = transform.position;

                //TODO: Move timeToNextAttack to EnemyCombat script so that EnemyMovement does not care about it.
                if (Time.time >= timeToNextAttack)
                {
                    timeToNextAttack = Time.time + combat.NextAttackTimer;
                    combat.Attack();                 
                }               
            }
        }
        else
        {
            if (Time.time >= timeToWander)
            {
                timeToWander = Time.time + Random.Range(5, 11);
                Wander();
            }
        }    
        
        transform.LookAt(destinationPosition);
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, MovementSpeed * Time.deltaTime);
    }

    void Wander()
    {      
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector3 randomPosition = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        randomPosition *= Random.Range(0.5f, 7);

        destinationPosition = transform.position - randomPosition;
    }
}
