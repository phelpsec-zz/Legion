using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    private GameObject deathScreen;
    private GameObject respawnButton;
    private GameObject exitGameButton;

    private GameObject activeSkillPanel;
    private GameObject activeSkillButton;

    public GameObject DeathScreen { get { return deathScreen; } }

    void Awake()
    {
        deathScreen = GameObject.Find("Death Screen");
        respawnButton = GameObject.Find("Respawn Button");
        exitGameButton = GameObject.Find("Exit Game Button");

        //activeSkillPanel = GameObject.Find("Active Skill Panel");
        activeSkillButton = GameObject.Find("Active Skill Button");
    }

    void Start()
    {
        deathScreen.SetActive(false);
        //activeSkillPanel.SetActive(false);
    }


    void Update()
    {

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

    public void ActivateSkillPanel()
    {
        Debug.Log("Activated Skill Panel.");
    }
}
