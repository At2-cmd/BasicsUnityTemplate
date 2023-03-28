using Rotatelab.FSM;
using Unity.VisualScripting;

public class PlayerStateType : StateType<PlayerStateType>
{
    public static readonly PlayerStateType Idle = new PlayerStateType(nameof(Idle));
	public static readonly PlayerStateType Walk = new PlayerStateType(nameof(Walk));
	public static readonly PlayerStateType Run = new PlayerStateType(nameof(Run));
	public static readonly PlayerStateType SprintRun = new PlayerStateType(nameof(SprintRun));
	public static readonly PlayerStateType Crounch = new PlayerStateType(nameof(Crounch));
	public static readonly PlayerStateType CrouchWalk = new PlayerStateType(nameof(CrouchWalk));
	public static readonly PlayerStateType Prone = new PlayerStateType(nameof(Prone));
            
    private PlayerStateType(string name) : base(name)
    {
        
    }
}

public abstract class PlayerBaseState : BaseState<PlayerController, PlayerStateType>
{
    protected PlayerBaseState(PlayerController owner, PlayerStateType type) : base(owner, type)
    {
        
    }

    public abstract void Update();
    public abstract void FixedUpdate();
}
