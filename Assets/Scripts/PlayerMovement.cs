using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 destinationPosition;
    private PlayerHealth healthManager;

    private float baseMovementSpeed = 15;

    private float MovementSpeed { get { return baseMovementSpeed; } set { } }

    void Awake()
    {
        healthManager = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        destinationPosition = transform.position;
    }

    void Update()
    {
        if (!healthManager.IsDead)
        {
            if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Plane playerPlane = new Plane(Vector3.up, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float distance;

                if (playerPlane.Raycast(ray, out distance))
                {
                    destinationPosition = ray.GetPoint(distance);
                    transform.rotation = Quaternion.LookRotation(destinationPosition - transform.position);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                destinationPosition = transform.position;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationPosition, MovementSpeed * Time.deltaTime);
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            destinationPosition = transform.position;
        }
    }
}

