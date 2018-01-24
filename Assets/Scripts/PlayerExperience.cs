using UnityEngine;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    private float currentExperience = 20;

    private GameObject experienceBar;

    void Awake()
    {
        experienceBar = GameObject.Find("Experience");
    }

    void Start()
    {

    }

    void Update()
    {
        float experiencePercentage = currentExperience / 100;
        experienceBar.transform.localScale = new Vector3(experiencePercentage, experienceBar.transform.localScale.y, experienceBar.transform.localScale.z);
    }

}
