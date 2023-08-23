using UnityEngine;

public class EntityState
{
    protected EntityStateMachine stateMachine;
    protected Entity entity;
    protected float startTime;
    protected string animBoolName;

    public EntityState(Entity entity, EntityStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        DoChecks();
        entity.anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
    
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }
}
