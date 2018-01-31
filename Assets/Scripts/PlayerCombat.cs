using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool IsInCombat { get; set; }

    private float timeToNextAttack;
    private float globalCooldownTimer = 0.5f;

    protected GameObject spellSpawnPrefab;
    protected GameObject spellSpawn;
    protected Transform spellSpawnLocation;

    protected GameObject player;
    protected PlayerResource playerResource;

    public List<Spells> spells;
    public Spells activeSpell;

    protected string activeSpellName;
    protected GameObject activeSpellPrefab;

    protected virtual void Awake()
    {
        spellSpawnPrefab = Resources.Load("Prefabs/Spell Spawn") as GameObject;
        spellSpawn = Instantiate(spellSpawnPrefab, transform);
        spellSpawnLocation = spellSpawn.transform;

        player = GameObject.FindGameObjectWithTag("Player");
        playerResource = player.GetComponent<PlayerResource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)))
        {

            if (Time.time >= timeToNextAttack)
            {
                //TODO: Implement specific spell cooldowns into the timeToNextAttack formula.
                timeToNextAttack = Time.time + globalCooldownTimer;

                Attack();
            }                 
        }
    }

    //TODO: Get the active spell from the UI Active Spell Button (Implement this on each class's Attack method).
    protected virtual void Attack()
    {
        
    }
}
