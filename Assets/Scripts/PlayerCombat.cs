using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private bool isInCombat;
    public bool IsInCombat { get { return isInCombat; } set { isInCombat = value; } }

    private float timeToNextAttack;
    private float globalCooldownTimer = 0.5f;

    private GameObject projectileSpawnPrefab;
    private GameObject projectileSpawn;

    protected UIController uiController;

    void Awake()
    {
        uiController = GameObject.Find("UI").GetComponent<UIController>();
        projectileSpawnPrefab = (Resources.Load("Prefabs/Projectile Spawn")) as GameObject;
        projectileSpawn = Instantiate(projectileSpawnPrefab, gameObject.transform);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)))
        {
            if (Time.time >= timeToNextAttack)
            {
                timeToNextAttack = Time.time + globalCooldownTimer;
                Attack();
            }                 
        }
    }
    
    protected virtual void GetActiveSkill()
    {

    }

    protected virtual void Attack()
    {
        
    }
}
