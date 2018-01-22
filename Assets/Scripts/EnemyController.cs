using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    private float aggroRadius;
    private float timeToWander;
    private float attackRange;
    private float movementSpeed;

    private float lastAggrovatedTime;
    private float timeToUnAggro = 5f;
    private float lastAttackTime;
    private float timeToNextAttack;
    private float attackCooldown;

    protected float AggroRadius { get { return aggroRadius; } set { aggroRadius = value; } }
    protected float AttackRange { get { return attackRange; } set { attackRange = value; } }
    protected float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    protected float AttackCooldown { get { return attackCooldown; } set { attackCooldown = value; } }

    protected Vector3 destinationPosition;
    private Vector3 stopPosition;

    private bool isAggrovated;

    private GameObject player;
    private HealthManager playerHealth;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthManager>();
    }

    void Start()
    {


    }

    void Update()
    {
        if (!playerHealth.IsDead)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceFromPlayer <= aggroRadius)
            {
                isAggrovated = true;
                lastAggrovatedTime = Time.time;
            }
        }
              
        if (isAggrovated)
        {
            if (Time.time >= (lastAggrovatedTime + timeToUnAggro) || playerHealth.IsDead)
            {
                isAggrovated = false;
            }


            if (Vector3.Distance(transform.position, player.transform.position) > AttackRange)
            {
                destinationPosition = player.transform.position;
            }
            else
            {
                destinationPosition = transform.position;
                if (Time.time >= timeToNextAttack)
                {
                    Attack();
                }
                
            }
        }
        else
        {
            if (Time.time >= timeToWander)
            {
                Wander();
            }
        }    
        
        transform.LookAt(destinationPosition);
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, MovementSpeed * Time.deltaTime);
    }

    void Wander()
    {
        timeToWander = Time.time + Random.Range(5f, 11f);

        float angle = Random.Range(0f, Mathf.PI * 2);
        Vector3 randomPosition = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        randomPosition *= Random.Range(0.5f, 7f);

        destinationPosition = transform.position - randomPosition;
    }

    protected virtual void Attack()
    {
        timeToNextAttack = Time.time + attackCooldown;
    }
}
