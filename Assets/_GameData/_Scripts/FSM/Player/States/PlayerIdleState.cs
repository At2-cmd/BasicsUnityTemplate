using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isMoving = (horizontal != 0f) || (vertical != 0f);

        if (isMoving)
		{
			owner.StateMachine.ChangeState(PlayerStateType.Walk);
		}
    }
}
