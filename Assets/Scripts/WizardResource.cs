using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardResource : PlayerResource
{
    //Wizard Resource - Energy. 
    //Generates quickly at all times.
    //Degenerates on some attacks.

    void Awake()
    {
        resourceBar = GameObject.Find("Resource");
        resourceBar.GetComponent<Image>().color = new Color32(30, 0, 255, 255);
    }

    void Start()
    {
        StartingResource = 20;

        ResourceRegenerationRate = 12;
        ResourceDegenerationRate = 0;
        ResourceGenerateOnReceiveHit = 0;
    }
}
