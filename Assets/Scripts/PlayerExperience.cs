using UnityEngine;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    public float Level { get; set; }
    private float TotalExperience { get; set; }
    private float CurrentExperienceIntoLevel { get; set; }
    private float ExperienceToNextLevel { get; set; }

    private GameObject experienceBar;

    void Awake()
    {
        experienceBar = GameObject.Find("Experience");
    }

    void Start()
    {
        Level = 1;
        ExperienceToNextLevel = 200;

        UpdateExperienceBar();
    }

    void Update()
    {
        if (CurrentExperienceIntoLevel >= ExperienceToNextLevel)
        {
            Level += 1;
            CurrentExperienceIntoLevel = CurrentExperienceIntoLevel - ExperienceToNextLevel;
            ExperienceToNextLevel *= 1.5f;

            UpdateExperienceBar();
        }
    }
    
    void UpdateExperienceBar()
    {
        float experiencePercentage = CurrentExperienceIntoLevel / ExperienceToNextLevel;
        experienceBar.transform.localScale = new Vector3(experiencePercentage, experienceBar.transform.localScale.y, experienceBar.transform.localScale.z);      
    }

    public void AddToExperience(float experienceAmount)
    {
        TotalExperience += experienceAmount;
        CurrentExperienceIntoLevel += experienceAmount;

        UpdateExperienceBar();
    }
}
