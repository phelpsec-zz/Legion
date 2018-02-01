using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIExperienceBar : MonoBehaviour
{
    private GameObject experienceBar;

    private GameObject levelDisplayText;
    private Text levelDisplay;

    private GameObject player;
    private PlayerExperience playerExperience;

    void Awake()
    {
        experienceBar = GameObject.Find("Experience");

        levelDisplayText = GameObject.Find("Level Display Text");
        levelDisplay = levelDisplayText.GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerExperience = player.GetComponent<PlayerExperience>();
    }

    void Update()
    {
        experienceBar.transform.localScale = new Vector3(playerExperience.ExperiencePercentage, experienceBar.transform.localScale.y, experienceBar.transform.localScale.z);

        levelDisplay.text = ((int)playerExperience.Level).ToString();
    }
}
