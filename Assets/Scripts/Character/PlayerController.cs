using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput myController;
    public float moveSpeed;

    public Vector2 inputValue;

    Rigidbody2D rb;

    private void Awake()
    {
        myController = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        myController.Enable();
    }

    private void OnDisable()
    {
        myController.Disable();
    }

    private void Start()
    {
        myController.LocalPlayer.Move.performed += value => inputValue = value.ReadValue<Vector2>();
        myController.LocalPlayer.Move.canceled += _ => inputValue = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * inputValue);
    }


}
