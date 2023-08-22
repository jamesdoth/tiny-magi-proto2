using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;
    private string animBoolName;

    protected int xInput;
    protected int yInput;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }
    
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        player.SetVelocityX(playerData.movementVelocity * xInput);
        player.SetVelocityY(playerData.movementVelocity * yInput);
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }
}
