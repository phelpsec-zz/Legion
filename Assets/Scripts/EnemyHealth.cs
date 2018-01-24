using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;

    private GameObject enemyHealthBarPrefab;
    private GameObject enemyHealthBar;

    private Image healthBar;

    private EnemyCombat combat;
    private PlayerCombat playerCombat;

    private EnemyStats stats;

    private GameController game;

    void Awake()
    {
        stats = GetComponent<EnemyStats>();

        enemyHealthBarPrefab = (Resources.Load("Prefabs/Enemy Health Bar")) as GameObject;
        enemyHealthBar = Instantiate(enemyHealthBarPrefab, new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z), transform.rotation);

        healthBar = enemyHealthBar.transform.Find("Enemy Health").GetComponent<Image>();

        combat = GetComponent<EnemyCombat>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();

        game = GameObject.Find("Game").GetComponent<GameController>();
    }

    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            combat.IsAggrovated = false;
            playerCombat.IsInCombat = false;
            Death();
        }

        //if (currentHealth <= maxHealth)
        //{
        //    currentHealth -= 10 * Time.deltaTime;
        //}

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

    void Death()
    {
        Destroy(enemyHealthBar);
        Destroy(gameObject);
        game.EnemyDeath();
    }
}
