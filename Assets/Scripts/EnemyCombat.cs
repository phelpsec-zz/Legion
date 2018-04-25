using UnityEngine;
using System.Collections;

public abstract class EnemyCombat : MonoBehaviour
{
    private float nextAttackTimer;
    private float rangeToAttack;
    public float NextAttackTimer { get { return nextAttackTimer; } set { nextAttackTimer = value; } }
    public float RangeToAttack { get { return rangeToAttack; } set { rangeToAttack = value; } }

    private float aggroDistance;
    private bool isAggrovated;
    private float timeToUnAggro;
    private float unAggroTimer;
    protected float AggroDistance { get { return aggroDistance; } set { aggroDistance = value; } }
    public bool IsAggrovated { get { return isAggrovated; } set { isAggrovated = value; } }
    protected float UnAggroTimer { get { return unAggroTimer; } set { unAggroTimer = value; } }

    protected float Damage { get; set; }

    GameObject player;
    PlayerHealth playerHealth;
    PlayerCombat playerCombat;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerCombat = player.GetComponent<PlayerCombat>();
    }

    void Update()
    {
        if (!playerHealth.IsDead && !playerHealth.IsRespawning)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceFromPlayer <= aggroDistance)
            {               
                isAggrovated = true;
                playerCombat.IsInCombat = true;
                timeToUnAggro = Time.time + unAggroTimer;
            }
        }

        if (isAggrovated)
        {
            if (Time.time >= timeToUnAggro || playerHealth.IsDead)
            {
                isAggrovated = false;
                playerCombat.IsInCombat = false;
            }
        }
    }

    public abstract void Attack();
}
