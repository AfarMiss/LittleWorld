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

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * inputValue);
    }


}
