using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FarmGameController : MonoBehaviour
{
    [Range(3, 10)] public float walkSpeed = 3f;
    [Range(11, 20)] public float runSpeed = 5f;

    private Vector2 input;

    public void OnMove(CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        var localPlayer = GameObject.FindObjectOfType<FarmPlayer>();
        var rigidgBody = localPlayer.GetComponent<Rigidbody2D>();
        rigidgBody.MovePosition(rigidgBody.position + runSpeed * Time.deltaTime * input);
    }
}
