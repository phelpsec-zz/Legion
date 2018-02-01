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

    public float ResourcePercentage { get { return CurrentResource / 100; } }

    protected GameObject resourceBar;

    protected virtual void Update()
    {
        CurrentResource += (ResourceRegenerationRate - ResourceDegenerationRate) * Time.deltaTime;
        CurrentResource = CurrentResource < 0 ? 0 : CurrentResource;
        CurrentResource = CurrentResource > 100 ? 100 : CurrentResource;
    }

    public void GenerateResourceOnHitReceived()
    {
        CurrentResource += ResourceGenerateOnReceiveHit;
    }

    public void GenerateResourceOnHitDealt(float resourceAmount)
    {
        CurrentResource += resourceAmount;
    }

    public void GenerateResourceOnSpellCast(float resourceAmount)
    {
        CurrentResource += resourceAmount;
    }

    public void SpendResourceOnSpellCast(float resourceAmount)
    {
        CurrentResource -= resourceAmount;
    }
}
