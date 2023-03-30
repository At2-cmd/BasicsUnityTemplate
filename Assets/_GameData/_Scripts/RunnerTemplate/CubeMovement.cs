using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    private CubeInput cubeInput;
    private float newPosX;
    private float horizontalLimitValue = 1.4f;


    private void Awake()
    {
        cubeInput = GetComponent<CubeInput>();
    }

    private void Update()
    {
        MoveVertically();
        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        newPosX = transform.position.x + cubeInput.HorizontalInput * horizontalSpeed * Time.deltaTime;
        newPosX = Mathf.Clamp(newPosX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }

    private void MoveVertically()
    {
        transform.Translate(transform.forward * verticalSpeed * Time.deltaTime);
    }
}
