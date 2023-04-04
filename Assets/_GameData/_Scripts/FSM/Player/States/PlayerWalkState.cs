using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    private bool isMoving;
	public PlayerWalkState(PlayerController owner, PlayerStateType type) : base(owner, type)
	{
		
	}
	
	public override void Enter()
	{
        owner.AnimController.PlayAnim(PlayerAnimController.Walk);
    }
	
	public override void Exit()
	{
		
	}

    public override void FixedUpdate()
    {
        owner.MovePlayer(owner.WalkSpeed);
    }

    public override void Update()
    {
        owner.GetInput();
        owner.RotatePlayerToDirection(owner.WalkRotateSpeed);
        isMoving = InputManager.Instance.CheckMovementState();

        if (!isMoving)
        {
            owner.StateMachine.ChangeState(PlayerStateType.Idle);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            owner.StateMachine.ChangeState(PlayerStateType.Run);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            owner.StateMachine.ChangeState(PlayerStateType.Crounch);
        }
    }
}
