using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    private float baseVitality;
    protected float BaseVitality { get { return baseVitality; } set { baseVitality = value; } }

    public float BaseHealth { get { return baseVitality * 5; } }

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
