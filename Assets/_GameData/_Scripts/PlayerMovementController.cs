using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
        rb.MovePosition(transform.position + (direction * _speed * Time.deltaTime));
    }
}
