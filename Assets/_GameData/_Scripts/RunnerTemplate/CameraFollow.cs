using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float lerpValue;
    private Vector3 offset;


    private void Start()
    {
        offset = transform.position - _targetTransform.position;
    }

    private void LateUpdate()
    {
        SmoothCameraFollow();
    }

    private void SmoothCameraFollow()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, new Vector3(0, _targetTransform.position.y, _targetTransform.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = newPos;
    }

}
