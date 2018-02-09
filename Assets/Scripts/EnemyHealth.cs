using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    private GameObject enemyHealthBarPrefab;
    private GameObject enemyHealthBar;

    private Image healthBar;

    private EnemyCombat combat;
    private PlayerCombat playerCombat;
    private EnemyStats stats;
    private GameController game;
    private PlayerExperience playerExperience;

    void Awake()
    {
        enemyHealthBarPrefab = (Resources.Load("Prefabs/Enemy Health Bar")) as GameObject;

        combat = GetComponent<EnemyCombat>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        stats = GetComponent<EnemyStats>();       
        game = GameObject.Find("Game").GetComponent<GameController>();
        playerExperience = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperience>();
    }

    void Start()
    {
        maxHealth = stats.BaseHealth;
        currentHealth = maxHealth;

        enemyHealthBar = Instantiate(enemyHealthBarPrefab, new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z), transform.rotation);
        healthBar = enemyHealthBar.transform.Find("Enemy Health").GetComponent<Image>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            combat.IsAggrovated = false;
            playerCombat.IsInCombat = false;
            Death();
        }

        float healthPercentage = currentHealth / maxHealth;
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void LateUpdate()
    {
        enemyHealthBar.transform.position = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    public void TakeOverTimeDamage(float damageAmount)
    {
        currentHealth -= damageAmount * Time.deltaTime;
    }

    void Death()
    {
        Destroy(enemyHealthBar);
        Destroy(gameObject);
        playerExperience.AddToExperience(stats.ExperienceAmount);
        game.EnemyDeath();
    }
}
