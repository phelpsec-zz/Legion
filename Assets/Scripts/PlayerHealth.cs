using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    public float CurrentHealth { get { return currentHealth; } }
    public float MaxHealth { get { return maxHealth; } }

    private bool isDead;
    public bool IsDead { get { return isDead; } set { isDead = value; } }

    private float timeToRespawn;
    private float respawnTimer = 3;

    private bool isRespawning;
    public bool IsRespawning { get { return isRespawning; } set { isRespawning = value; } }

    private GameObject healthBar;
    private UIController uiController;
    private PlayerResource resource;
    private PlayerStats stats;
    private PlayerCombat combat;

    
    void Awake()
    {
        healthBar = GameObject.Find("Health");
        uiController = GameObject.Find("UI").GetComponent<UIController>();
        resource = GetComponent<PlayerResource>();
        stats = GetComponent<PlayerStats>();
        combat = GetComponent<PlayerCombat>();
    }

    void Start()
    {
        maxHealth = stats.BaseHealth;
        currentHealth = maxHealth;
    }

    void Update()
    {
        currentHealth = currentHealth >= maxHealth ? maxHealth : currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            resource.CurrentResource = 0;
            GetComponent<Rigidbody>().detectCollisions = false;
            uiController.DeathScreen.SetActive(true);
        }
        else
        {
            if (currentHealth < maxHealth && !combat.IsInCombat)
            {
                currentHealth += stats.BaseHealthRegenRate * Time.deltaTime;
                //currentHealth -= 50 * Time.deltaTime;
            }
            
            if (isRespawning && Time.time >= timeToRespawn)
            {
                isRespawning = false;
                GetComponent<Rigidbody>().detectCollisions = true;
            }
        }

        float healthPercentage = currentHealth / maxHealth;
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void Respawn()
    {
        isDead = false;
        currentHealth = maxHealth;

        isRespawning = true;
        timeToRespawn = Time.time + respawnTimer;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        PlayerResource resource = GetComponent<PlayerResource>();
        if (resource.ResourceGenerateOnReceiveHit > 0)
        {
            resource.GenerateResourceOnHitReceived();
        }
    }
}
