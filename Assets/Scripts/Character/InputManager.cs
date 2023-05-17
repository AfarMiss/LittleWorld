using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoSingleton<InputManager>
{
    public PlayerInput myController => FindObjectOfType<PlayerInput>();
}
