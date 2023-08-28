using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_IdleState : EntityIdleState
{
    private EMelee enemy;
    public EM_IdleState(Entity entity, EntityStateMachine stateMachine, string animBoolName, EntityDataIdle stateData, EMelee enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
