using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    protected float currentResource;

    private float resourceRegenerationRate;
    private float resourceDegenerationRate;
    private float regenOnReceiveHit;

    private GameObject resourceBar;

    public float ResourceRegenerationRate { get { return resourceRegenerationRate; } set { resourceRegenerationRate = value; } }
    public float ResourceDegenerationRate { get { return resourceDegenerationRate; } set { resourceDegenerationRate = value; } }
    public float RegenOnReceiveHit { get { return regenOnReceiveHit; } set { regenOnReceiveHit = value; } }

    public float CurrentResource { get { return currentResource; } set { currentResource = value; } }

    void Awake() {

        resourceBar = GameObject.Find("Resource");
    }

    void Start() {

    }

    void Update() {

        currentResource += (ResourceRegenerationRate - ResourceDegenerationRate) * Time.deltaTime;
        currentResource = currentResource < 0f ? 0f : currentResource;
        currentResource = currentResource > 100 ? 100f : currentResource;

        float resourcePercentage = currentResource / 100f;
        resourceBar.transform.localScale = new Vector3(resourcePercentage, resourceBar.transform.localScale.y, resourceBar.transform.localScale.z);
    }
}
