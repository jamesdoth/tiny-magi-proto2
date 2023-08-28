using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMelee : Entity
{
    public EM_IdleState idleState { get; private set; }
    public EM_MoveState moveState { get; private set; }

    [SerializeField]
    private EntityDataIdle idleStateData;
    [SerializeField]
    private EntityDataMove moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new EM_MoveState(this, stateMachine, "move", moveStateData, this);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void SetVelocity(float velocity)
    {
        base.SetVelocity(velocity);
    }

    public override void Flip()
    {
        base.Flip();
    }
}
