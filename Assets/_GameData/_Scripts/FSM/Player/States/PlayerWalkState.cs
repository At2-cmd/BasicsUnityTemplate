using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
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
        owner.MovePlayer();
    }

    public override void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isMoving = (horizontal != 0f) || (vertical != 0f);

        owner.GetInput();
        owner.RotatePlayerToDirection();

        if (!isMoving)
        {
            owner.StateMachine.ChangeState(PlayerStateType.Idle);
        }
    }
}
