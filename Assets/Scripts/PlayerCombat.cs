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

    void Awake()
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
            GetActiveSpell();

            if (Time.time >= timeToNextAttack)
            {
                //TODO: Implement specific spell cooldowns into the timeToNextAttack formula.
                timeToNextAttack = Time.time + globalCooldownTimer;

                Attack();
            }                 
        }
    }

    void Attack()
    {
        if (playerResource.CurrentResource >= activeSpell.ResourceCost)
        {
            Instantiate(activeSpellPrefab, spellSpawnLocation.position, spellSpawnLocation.rotation);

            playerResource.GenerateResourceOnSpellCast(activeSpell.ResourceGenerate);
            playerResource.SpendResourceOnSpellCast(activeSpell.ResourceCost);
        }
        else
        {
            //TODO: Display UI Text saying "Not enough [ResourceName]."
            Debug.Log("Not enough " + playerResource.ResourceName);
        }
    }

    private GameObject GetActiveSpell()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].IsActive)
            {
                activeSpellName = spells[i].SpellName;
                activeSpell = spells[i];
            }
        }

        activeSpellPrefab = Resources.Load("Prefabs/" + activeSpellName) as GameObject;
        return activeSpellPrefab;
    }
}
