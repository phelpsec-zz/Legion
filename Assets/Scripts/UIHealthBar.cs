using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private GameObject healthBar;

    private GameObject healthDisplayText;
    private Text healthDisplay;

    private GameObject player;
    private PlayerHealth playerHealth;

    void Awake()
    {
        healthBar = GameObject.Find("Health");

        healthDisplayText = GameObject.Find("Health Display Text");
        healthDisplay = healthDisplayText.GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        HideHealthText();
    }

    void Update()
    {
        healthBar.transform.localScale = new Vector3(playerHealth.HealthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        healthDisplay.text = ((int)playerHealth.CurrentHealth + " / " + (int)playerHealth.MaxHealth).ToString();
    }

    public void DisplayHealthText()
    {
        healthDisplayText.SetActive(true);
    }

    public void HideHealthText()
    {
        healthDisplayText.SetActive(false);
    }
}
