using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public PlayerInput myController;
    void Awake()
    {
        Instance = this;
        myController = new PlayerInput();
        myController.Enable();
    }

    private void OnDestroy()
    {
        myController = null;
        myController.Disable();
    }


}
