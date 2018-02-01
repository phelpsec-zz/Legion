using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIDeathScreen : MonoBehaviour
{
    public GameObject DeathScreen { get; set; }
    private GameObject respawnButton;
    private GameObject exitGameButton;

    private GameObject player;
    private PlayerHealth playerHealth;

    void Awake()
    {
        DeathScreen = GameObject.Find("Death Screen");
        respawnButton = GameObject.Find("Respawn Button");
        exitGameButton = GameObject.Find("Exit Game Button");

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        DeathScreen.SetActive(false);
    }

    public void RespawnButton()
    {
        DeathScreen.SetActive(false);
        playerHealth.Respawn();
    }

    public void ExitGameButton()
    {

    }
}
