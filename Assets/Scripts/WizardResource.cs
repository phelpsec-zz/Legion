using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardResource : ResourceManager {

    void Start() {

        ResourceRegenerationRate = 10f;
        ResourceDegenerationRate = 0f;
        RegenOnReceiveHit = 0f;

        currentResource = 0f;

        GameObject resourceBar = GameObject.Find("Resource");
        GameObject resourceBarBackground = GameObject.Find("Resource Background");

        resourceBar.GetComponent<Image>().color = new Color32(30, 0, 255, 255);
        resourceBarBackground.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
    }

}
