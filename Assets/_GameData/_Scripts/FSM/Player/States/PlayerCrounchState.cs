using UnityEngine;

public class PlayerCrounchState : PlayerBaseState
{
	private bool isMoving;
	public PlayerCrounchState(PlayerController owner, PlayerStateType type) : base(owner, type)
	{
		
	}
	
	public override void Enter()
	{
        owner.AnimController.PlayAnim(PlayerAnimController.Crouch);
    }
	
	public override void Exit()
	{
		
	}

    public override void FixedUpdate()
    {
        
    }

    public override void Update()
    {
        isMoving = owner.CheckMovementState();

        if (isMoving)
        {
            owner.StateMachine.ChangeState(PlayerStateType.CrouchWalk);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            owner.StateMachine.ChangeState(PlayerStateType.Idle);
        }
    }
}
