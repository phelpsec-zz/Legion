//using UnityEngine;
//using System.Collections;

//public class SpellsLeap : MonoBehaviour
//{
//    private GameObject centerPositionObject;
//    private Vector3 targetAngles;

//    private GameObject player;
//    private PlayerMovement movement;
//    private PlayerCombat combat;

//    void Awake()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        movement = player.GetComponent<PlayerMovement>();
//        combat = player.GetComponent<PlayerCombat>();
//    }

//    void Start()
//    {


//        centerPositionObject = new GameObject();
//        centerPositionObject.transform.position = (transform.position + player.transform.position) * 0.5f;

//        player.transform.SetParent(centerPositionObject.transform);

//        targetAngles = centerPositionObject.transform.eulerAngles + 180f * Vector3.forward;
//    }

//    void Update()
//    {
//        if (centerPositionObject)
//        {
//            player.transform.rotation = centerPositionObject.transform.rotation;

//            centerPositionObject.transform.eulerAngles = Vector3.Lerp(centerPositionObject.transform.eulerAngles, targetAngles, 1f * Time.deltaTime);
//        }
//    }

//}
