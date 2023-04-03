using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private PlayerAnimController _animController;
    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //_animController = new PlayerAnimController(GetComponent<Animator>());
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        RotatePlayerToDirection();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        direction = new Vector3(InputManager.Instance.horizontalInput, transform.position.y, InputManager.Instance.verticalInput);
    }
    private void MovePlayer()
    {
        rb.MovePosition(transform.position + (direction * _moveSpeed * Time.deltaTime));
    }

    private void RotatePlayerToDirection()
    {
        // If the player is not moving, do not rotate
        if (direction.magnitude < 0.1f) return;

        // Calculate the target rotation based on the direction vector
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly interpolate between the current rotation and the target rotation using Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    }

}
