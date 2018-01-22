using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarbarianResource : ResourceManager {

    void Start() {

        ResourceRegenerationRate = 0f;
        ResourceDegenerationRate = 1f;
        RegenOnReceiveHit = 6f;

        currentResource = 50f;

        GameObject resourceBar = GameObject.Find("Resource");
        GameObject resourceBarBackground = GameObject.Find("Resource Background");

        resourceBar.GetComponent<Image>().color = new Color32(255, 170, 0, 255);
        resourceBarBackground.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
    }

}
