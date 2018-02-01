using UnityEngine;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    public float Level { get; set; }
    private float TotalExperience { get; set; }
    private float CurrentExperienceIntoLevel { get; set; }
    private float ExperienceToNextLevel { get; set; }

    public float ExperiencePercentage { get { return CurrentExperienceIntoLevel / ExperienceToNextLevel; } }

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
            ExperienceToNextLevel *= 1.5f;
        }
    }

    public void AddToExperience(float experienceAmount)
    {
        TotalExperience += experienceAmount;
        CurrentExperienceIntoLevel += experienceAmount;
    }
}
