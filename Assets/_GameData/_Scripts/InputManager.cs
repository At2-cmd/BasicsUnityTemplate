using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField] private FloatingJoystick floatingJS;
    public float horizontalInput;
    public float verticalInput;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        horizontalInput = floatingJS.Horizontal;
        verticalInput = floatingJS.Vertical;
    }
}
