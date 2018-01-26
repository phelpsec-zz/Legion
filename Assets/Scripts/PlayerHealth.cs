using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public bool IsDead { get; set; }
    public bool IsRespawning { get; set; }

    private float timeToRespawn;
    private int respawnTimer = 3;

    private GameObject healthBar;
    private GameObject deathScreen;
    private PlayerResource resource;
    private PlayerStats stats;
    private PlayerCombat combat;
    
    void Awake()
    {
        healthBar = GameObject.Find("Health");
        deathScreen = GameObject.Find("Death Screen");
        resource = GetComponent<PlayerResource>();
        stats = GetComponent<PlayerStats>();
        combat = GetComponent<PlayerCombat>();
    }

    void Start()
    {
        //TODO: Eventually, MaxHealth will be BaseHealth + any Vitality from future equipped items.
        MaxHealth = stats.BaseHealth;
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        CurrentHealth = CurrentHealth >= MaxHealth ? MaxHealth : CurrentHealth;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            IsDead = true;
            resource.CurrentResource = 0;
            GetComponent<Rigidbody>().detectCollisions = false;
            deathScreen.SetActive(true);
        }
        else
        {
            if (CurrentHealth < MaxHealth && !combat.IsInCombat)
            {
                CurrentHealth += stats.BaseHealthRegenRate * Time.deltaTime;
            }
            
            if (IsRespawning && Time.time >= timeToRespawn)
            {
                IsRespawning = false;
                GetComponent<Rigidbody>().detectCollisions = true;
            }
        }

        float healthPercentage = CurrentHealth / MaxHealth;
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void Respawn()
    {
        IsDead = false;
        CurrentHealth = MaxHealth;

        IsRespawning = true;
        timeToRespawn = Time.time + respawnTimer;
    }

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (resource.ResourceGenerateOnReceiveHit > 0)
        {
            resource.GenerateResourceOnHitReceived();
        }
    }
}
