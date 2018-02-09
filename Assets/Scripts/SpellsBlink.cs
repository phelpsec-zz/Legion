using UnityEngine;
using System.Collections;

public class SpellsBlink : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        player.transform.position = transform.position;

        Destroy(gameObject);
    }
}
