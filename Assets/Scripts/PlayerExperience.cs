using UnityEngine;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    private GameObject experienceBar;

    private float Level { get; set; }

    private float TotalExperience { get; set; }
    private float CurrentExperienceIntoLevel { get; set; }
    private float ExperienceToNextLevel { get; set; }

    void Awake()
    {
        experienceBar = GameObject.Find("Experience");
    }

    void Start()
    {
        Level = 1;
        ExperienceToNextLevel = 200;
    }

    void Update()
    {
        if (CurrentExperienceIntoLevel >= ExperienceToNextLevel)
        {
            Level += 1;
            CurrentExperienceIntoLevel = CurrentExperienceIntoLevel - ExperienceToNextLevel;

            CalculateExperienceToNextLevel();
        }

        float experiencePercentage = CurrentExperienceIntoLevel / ExperienceToNextLevel;
        experienceBar.transform.localScale = new Vector3(experiencePercentage, experienceBar.transform.localScale.y, experienceBar.transform.localScale.z);
    }

    void CalculateExperienceToNextLevel()
    {
        ExperienceToNextLevel *= 1.5f;
    }

    public void AddToExperience(float experienceAmount)
    {
        TotalExperience += experienceAmount;
        CurrentExperienceIntoLevel += experienceAmount;
    }
}
