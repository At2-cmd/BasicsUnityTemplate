using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    private bool isMoving;

    public PlayerRunState(PlayerController owner, PlayerStateType type) : base(owner, type)
	{
		
	}
	
	public override void Enter()
	{
        owner.AnimController.PlayAnim(PlayerAnimController.Run);
    }
	
	public override void Exit()
	{
		
	}

    public override void FixedUpdate()
    {
        owner.MovePlayer(owner.RunSpeed);
    }

    public override void Update()
    {
        owner.GetInput();
        owner.RotatePlayerToDirection(owner.RunRotateSpeed);
        isMoving = owner.CheckMovementState();

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            owner.StateMachine.ChangeState(PlayerStateType.Walk);
        }

        if (!isMoving)
        {
            owner.StateMachine.ChangeState(PlayerStateType.Idle);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            owner.StateMachine.ChangeState(PlayerStateType.Crounch);
        }
    }
}
