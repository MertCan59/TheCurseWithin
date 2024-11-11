using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private MovementController movementController;

    private void FixedUpdate()
    {
        movementController.Move();
    }

    private void OnEnable()
    {
        movementController.OnEnable();
    }

    private void OnDisable()
    {
        movementController.OnDisable();
    }
}
