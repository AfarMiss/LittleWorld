using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    PlayerInput myController;
    void Awake()
    {
        myController = new PlayerInput();
    }

    private void OnDestroy()
    {
        myController = null;
    }


}
