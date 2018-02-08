using UnityEngine;
using System.Collections;

public class SpellsBlink : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        player.transform.position = transform.position;

        Destroy(gameObject);
    }

}
