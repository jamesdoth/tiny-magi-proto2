using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_MoveState : EntityMoveState
{
    private EMelee enemy;
    public EM_MoveState(Entity entity, EntityStateMachine stateMachine, string animBoolName, EntityDataMove stateData, EMelee enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // emelee move logic + idle state transition stateMachine.ChangeState(entity.idleState);
        if(/*enemy logic*/enemy)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
