using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController
{
    private Animator _animator;
    private const float AnimTranDuration = 0.15f;


    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Walk = Animator.StringToHash("Walk");
    public static readonly int Run = Animator.StringToHash("Run");
    public static readonly int Crouch = Animator.StringToHash("Crouch");
    public static readonly int CrouchWalk = Animator.StringToHash("CrouchWalk");

    public PlayerAnimController(Animator animator)
    {
        _animator = animator;
    }

    public void PlayAnim(int animHash)
    {
        _animator.CrossFade(animHash, AnimTranDuration);
    }
}
