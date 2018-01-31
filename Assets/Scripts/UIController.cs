using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject healthDisplayText;
    private Text healthDisplay;

    private GameObject resourceDisplayText;
    private Text resourceDisplay;

    private GameObject levelDisplayText;
    private Text levelDisplay;

    private GameObject deathScreen;
    private GameObject respawnButton;
    private GameObject exitGameButton;

    private GameObject activeSkillPanel;
    private GameObject activeSkillButton;

    public GameObject DeathScreen { get; set; }

    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerResource playerResource;
    private PlayerExperience playerExperience;
    private PlayerCombat playerCombat;

    void Awake()
    {
        healthDisplayText = GameObject.Find("Health Display Text");
        healthDisplay = healthDisplayText.GetComponent<Text>();

        resourceDisplayText = GameObject.Find("Resource Display Text");
        resourceDisplay = resourceDisplayText.GetComponent<Text>();

        levelDisplayText = GameObject.Find("Level Display Text");
        levelDisplay = levelDisplayText.GetComponent<Text>();

        deathScreen = GameObject.Find("Death Screen");
        respawnButton = GameObject.Find("Respawn Button");
        exitGameButton = GameObject.Find("Exit Game Button");

        activeSkillButton = GameObject.Find("Active Skill Button");
        activeSkillPanel = GameObject.Find("Active Skill Panel");

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerResource = player.GetComponent<PlayerResource>();
        playerExperience = player.GetComponent<PlayerExperience>();
        playerCombat = player.GetComponent<PlayerCombat>();
    }

    void Start()
    {
        deathScreen.SetActive(false);
        healthDisplayText.SetActive(false);
        resourceDisplayText.SetActive(false);
        activeSkillPanel.SetActive(false);
    }

    void Update()
    {
        healthDisplay.text = ((int)playerHealth.CurrentHealth + " / " + (int)playerHealth.MaxHealth).ToString();
        resourceDisplay.text = ((int)playerResource.CurrentResource + " / 100").ToString();
        levelDisplay.text = ((int)playerExperience.Level).ToString();
    }

    public void RespawnButton()
    {
        deathScreen.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth healthManager = player.GetComponent<PlayerHealth>();

        healthManager.Respawn();
    }

    public void ExitGameButton()
    {

    }

    public void DisplayHealthText()
    {
        healthDisplayText.SetActive(true);
    }

    public void HideHealthText()
    {
        healthDisplayText.SetActive(false);
    }

    public void DisplayResourceText()
    {
        resourceDisplayText.SetActive(true);
    }

    public void HideResourceText()
    {
        resourceDisplayText.SetActive(false);
    }

    public void DisplaySkillPanel()
    {
        activeSkillPanel.SetActive(true);
    }

    public void HideSkillPanel()
    {
        activeSkillPanel.SetActive(false);
    }
}
