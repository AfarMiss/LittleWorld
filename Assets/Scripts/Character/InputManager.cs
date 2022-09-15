using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public PlayerInput myController;
    void Awake()
    {
        Instance = this;
        Instance.myController.SwitchCurrentActionMap("сно╥");
    }

    private void OnDestroy()
    {
        myController = null;
    }
}
