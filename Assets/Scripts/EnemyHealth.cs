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

    private EnemyStats stats;

    void Awake()
    {
        stats = GetComponent<EnemyStats>();

        enemyHealthBarPrefab = (Resources.Load("Prefabs/Enemy Health Bar")) as GameObject;
        enemyHealthBar = Instantiate(enemyHealthBarPrefab, new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z), transform.rotation);

        healthBar = enemyHealthBar.transform.Find("Enemy Health").GetComponent<Image>();
    }

    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {   
        float healthPercentage = currentHealth / maxHealth;
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void LateUpdate()
    {
        enemyHealthBar.transform.position = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);
    }
}
