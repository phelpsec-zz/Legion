using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    //public float maxHealth;
    private float maxHealth;
    private float currentHealth;

    private float health;

    private bool isDead;
    private bool isRespawning;

    private float timeToRespawn;
    private float respawnTimer;

    private GameObject healthBar;
    private GameObject uiCanvas;
    private UIController uiController;
    private ResourceManager resource;

    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }

    void Awake() {

        healthBar = GameObject.Find("Health");
        uiCanvas = GameObject.Find("UI");
        uiController = uiCanvas.GetComponent<UIController>();
        resource = GetComponent<ResourceManager>();
    }

    void Start() {

    }

    void Update() {

        currentHealth = currentHealth >= maxHealth ? maxHealth : currentHealth;

        if (currentHealth <= 0f) {

            currentHealth = 0f;
            isDead = true;
            resource.CurrentResource = 0f;
            GetComponent<Rigidbody>().detectCollisions = false;           
            uiController.DeathScreen.SetActive(true);
        } else {

            if (currentHealth < maxHealth) {
                currentHealth += GetComponent<StatsManager>().GetHealthRegenerationRate() * Time.deltaTime;
                //currentHealth -= 50f * Time.deltaTime;
            }
        }

        float healthPercentage = currentHealth / maxHealth;
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void Respawn() {

        isDead = false;
        currentHealth = maxHealth;
        GetComponent<Rigidbody>().detectCollisions = true;
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player took " + damage + " damage.");
        currentHealth -= damage;
    }
}
