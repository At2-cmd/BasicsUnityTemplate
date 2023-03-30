using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInput : MonoBehaviour
{
    private float horizontalInput;
    public float HorizontalInput => horizontalInput;

    private void Update()
    {
        GetHorizontalInput();
    }

    private void GetHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalInput = Input.GetAxis("Mouse X");
        }
        else 
        {
            horizontalInput = 0;
        }
    }
}
