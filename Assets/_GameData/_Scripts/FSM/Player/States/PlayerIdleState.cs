using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
	private bool isMoving;
	public PlayerIdleState(PlayerController owner, PlayerStateType type) : base(owner, type)
	{
		
	}
	
	public override void Enter()
	{
		owner.AnimController.PlayAnim(PlayerAnimController.Idle);
    }
	
	public override void Exit()
	{
		
	}

    public override void FixedUpdate()
    {
        
    }

    public override void Update()
    {
		if (InputManager.Instance != null)
		{
            isMoving = InputManager.Instance.CheckMovementState();
        }

        if (isMoving)
		{
			owner.StateMachine.ChangeState(PlayerStateType.Walk);
		}

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            owner.StateMachine.ChangeState(PlayerStateType.Crounch);
        }
    }
}
