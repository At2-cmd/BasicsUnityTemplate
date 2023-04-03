using Rotatelab.Manager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static InputManager;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField] private FloatingJoystick floatingJS;
    [SerializeField] private ControlType controlType;
    public float horizontalInput;
    public float verticalInput;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (controlType)
        {
            case ControlType.MOUSE:
                horizontalInput = floatingJS.Horizontal;
                verticalInput = floatingJS.Vertical;
                break;

            case ControlType.KEYBOARD:
                horizontalInput = Input.GetAxis("Horizontal");
                verticalInput = Input.GetAxis("Vertical");
                break;
        }

        //horizontalInput = floatingJS.Horizontal;
        //verticalInput = floatingJS.Vertical;

        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
    }

    public enum ControlType 
    {
        MOUSE,
        KEYBOARD
    }
}
