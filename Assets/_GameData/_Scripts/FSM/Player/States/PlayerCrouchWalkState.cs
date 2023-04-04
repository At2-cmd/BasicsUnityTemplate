using UnityEngine;

public class PlayerCrouchWalkState : PlayerBaseState
{
	private bool isMoving;
	public PlayerCrouchWalkState(PlayerController owner, PlayerStateType type) : base(owner, type)
	{
		
	}
	
	public override void Enter()
	{
        owner.AnimController.PlayAnim(PlayerAnimController.CrouchWalk);
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
        owner.RotatePlayerToDirection(owner.WalkRotateSpeed / 2);
        isMoving = InputManager.Instance.CheckMovementState();

        if (!isMoving)
        {
            owner.StateMachine.ChangeState(PlayerStateType.Crounch);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            owner.StateMachine.ChangeState(PlayerStateType.Idle);
        }
    }
}
