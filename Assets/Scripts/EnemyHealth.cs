using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;

    private GameObject enemyHealthBarPrefab;
    private GameObject enemyHealthBar;

    private Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        enemyHealthBarPrefab = (Resources.Load("Prefabs/Enemy Health Bar")) as GameObject;
        enemyHealthBar = Instantiate(enemyHealthBarPrefab, new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z), transform.rotation);

        healthBar = enemyHealthBar.transform.Find("Enemy Health").GetComponent<Image>();
    }

    void Update()
    {
        enemyHealthBar.transform.position = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);

        float healthPercentage = currentHealth / maxHealth;
        healthBar.rectTransform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
