using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool IsMoving { get; set; }

    private Vector3 destinationPosition;
    private PlayerHealth healthManager;

    private float baseMovementSpeed = 15;
    private float MovementSpeed { get; set; }

    void Awake()
    {
        healthManager = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        //TODO: Include Movement Speed from future items.
        MovementSpeed = baseMovementSpeed;
        destinationPosition = transform.position;
    }

    void Update()
    {
        if (!healthManager.IsDead)
        {
            if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                IsMoving = true;
                LookAtMousePosition();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsMoving = false;
                LookAtMousePosition();

                GetComponent<Rigidbody>().velocity = Vector3.zero;
                destinationPosition = transform.position;
            }
            else
            {
                if (IsMoving)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destinationPosition, MovementSpeed * Time.deltaTime);

                    if (destinationPosition == transform.position)
                    {
                        IsMoving = false;
                    }
                }
            }
        }
        else
        {
            IsMoving = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            destinationPosition = transform.position;
        }       
    }

    void LookAtMousePosition()
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
}

