using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarbarianResource : PlayerResource
{
    //Barbarian Resource - Rage. 
    //Generates on some attacks, and when receiving a hit.
    //Degenerates on some attacks, and slowly after the Barbarian has been out of combat for a short time.

    private PlayerCombat combat;

    void Awake()
    {
        resourceBar = GameObject.Find("Resource");
        resourceBar.GetComponent<Image>().color = new Color32(255, 170, 0, 255);

        combat = GetComponent<PlayerCombat>();
    }

    void Start()
    {
        StartingResource = 50;

        ResourceRegenerationRate = 0;
        ResourceDegenerationRate = 1;
        ResourceGenerateOnReceiveHit = 5;
    }

    protected override void Update()
    {
        if (!combat.IsInCombat)
        {
            CurrentResource += (ResourceRegenerationRate - ResourceDegenerationRate) * Time.deltaTime;
        }

        CurrentResource = CurrentResource < 0 ? 0 : CurrentResource;
        CurrentResource = CurrentResource > 100 ? 100 : CurrentResource;

        float resourcePercentage = CurrentResource / 100;
        resourceBar.transform.localScale = new Vector3(resourcePercentage, resourceBar.transform.localScale.y, resourceBar.transform.localScale.z);
    }
}
