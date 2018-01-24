using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
    private float currentResource;
    private float resourceRegenerationRate;
    private float resourceDegenerationRate;
    private float resourceGenerateOnReceiveHit;
    private float resourceGenerateOnDealHit;

    protected GameObject resourceBar;
    private GameObject resourceBarBackground;

    protected float StartingResource { set { currentResource = value; } }
    public float CurrentResource { get { return currentResource; } set { currentResource = value; } }
    protected float ResourceRegenerationRate { get { return resourceRegenerationRate; } set { resourceRegenerationRate = value; } }
    protected float ResourceDegenerationRate { get { return resourceDegenerationRate; } set { resourceDegenerationRate = value; } }
    public float ResourceGenerateOnReceiveHit { get { return resourceGenerateOnReceiveHit; } set { resourceGenerateOnReceiveHit = value; } }
    public float ResourceGenerateOnDealHit { get { return resourceGenerateOnDealHit; } set { resourceGenerateOnDealHit = value; } }

    void Awake()
    {
        resourceBar = GameObject.Find("Resource");
        resourceBarBackground = GameObject.Find("Resource Background");
        resourceBarBackground.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
    }

    void Start()
    {

    }

    protected virtual void Update()
    {
        currentResource += (ResourceRegenerationRate - ResourceDegenerationRate) * Time.deltaTime;
        currentResource = currentResource < 0 ? 0 : currentResource;
        currentResource = currentResource > 100 ? 100 : currentResource;

        float resourcePercentage = currentResource / 100;
        resourceBar.transform.localScale = new Vector3(resourcePercentage, resourceBar.transform.localScale.y, resourceBar.transform.localScale.z);
    }


    //TODO: Implement spell resource generation.

    public void GenerateResourceOnHitReceived()
    {
        currentResource += resourceGenerateOnReceiveHit;
    }

    public void GenerateResourceOnHitDealt(float resourceAmount)
    {
        currentResource += resourceAmount;
    }

    void GenerateResourceOnSpellCast(float resourceAmount)
    {
        currentResource += resourceAmount;
    }

    void DegenerateResourceOnSpellCast(float resourceAmount)
    {
        currentResource -= resourceAmount;
    }
}
