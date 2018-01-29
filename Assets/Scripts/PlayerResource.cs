using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
    public string ResourceName { get; set; }
    public float CurrentResource { get; set; }
    protected float ResourceRegenerationRate { get; set; }
    protected float ResourceDegenerationRate { get; set; }
    public float ResourceGenerateOnReceiveHit { get; set; }

    protected GameObject resourceBar;

    void Awake()
    {
        resourceBar = GameObject.Find("Resource");
    }

    void Start()
    {

    }

    protected virtual void Update()
    {
        CurrentResource += (ResourceRegenerationRate - ResourceDegenerationRate) * Time.deltaTime;
        CurrentResource = CurrentResource < 0 ? 0 : CurrentResource;
        CurrentResource = CurrentResource > 100 ? 100 : CurrentResource;

        float resourcePercentage = CurrentResource / 100;
        resourceBar.transform.localScale = new Vector3(resourcePercentage, resourceBar.transform.localScale.y, resourceBar.transform.localScale.z);
    }

    public void GenerateResourceOnHitReceived()
    {
        CurrentResource += ResourceGenerateOnReceiveHit;
    }

    public void GenerateResourceOnHitDealt(float resourceAmount)
    {
        CurrentResource += resourceAmount;
    }

    //TODO: Implement spell resource generation/degeneration on spell casts.
    void GenerateResourceOnSpellCast(float resourceAmount)
    {
        CurrentResource += resourceAmount;
    }

    void SpendResourceOnSpellCast(float resourceAmount)
    {
        CurrentResource -= resourceAmount;
    }
}
