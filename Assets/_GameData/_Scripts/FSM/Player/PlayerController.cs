using Rotatelab.FSM;
using Rotatelab.Manager;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _walkRotateSpeed;
    [SerializeField] private float _runRotateSpeed;
    [SerializeField] private string _stateName;
    private PlayerAnimController _animController;
    private Rigidbody rb;
    private Vector3 direction;

    public PlayerAnimController AnimController => _animController;
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float WalkRotateSpeed => _walkRotateSpeed;
    public float RunRotateSpeed => _runRotateSpeed;


    private readonly StateMachine<PlayerController, PlayerBaseState, PlayerStateType> _stateMachine = new StateMachine<PlayerController, PlayerBaseState, PlayerStateType>();
    public StateMachine<PlayerController, PlayerBaseState, PlayerStateType> StateMachine => _stateMachine;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        SignUpEvents();
    }

    private void Init()
    {
        InitComponents();
        InitVariables();
        InitStateMachine();
    }

    private void InitComponents()
    {
        rb = GetComponent<Rigidbody>();
        _animController = new PlayerAnimController(GetComponentInChildren<Animator>());
    }

    private void InitVariables()
    {

    }

    private void InitStateMachine()
    {
        var states = new PlayerBaseState[]
        {
            new PlayerIdleState(this, PlayerStateType.Idle),
			new PlayerWalkState(this, PlayerStateType.Walk),
			new PlayerRunState(this, PlayerStateType.Run),
			new PlayerSprintRunState(this, PlayerStateType.SprintRun),
			new PlayerCrounchState(this, PlayerStateType.Crounch),
			new PlayerCrouchWalkState(this, PlayerStateType.CrouchWalk),
			new PlayerProneState(this, PlayerStateType.Prone)
        };
        
        _stateMachine.Init(PlayerStateType.Idle, states);
    }

    private void SignUpEvents()
    {
        
    }

    private void Update()
    {
        _stateName = _stateMachine.CurrentState.type.Name;
        StateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();
    }


    public void GetInput()
    {
        direction = new Vector3(InputManager.Instance.horizontalInput, transform.position.y, InputManager.Instance.verticalInput).normalized;
    }
    public void MovePlayer(float speed)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    public void RotatePlayerToDirection(float rotationSpeed)
    {
        if (direction.magnitude < 0.1f) return;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}