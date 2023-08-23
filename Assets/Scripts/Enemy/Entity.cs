using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStateMachine stateMachine;
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public int facingDirection {  get; private set; }
    private Vector2 workspace;

    public virtual void Start()
    {
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent <Animator>();
        aliveGO = transform.Find("Alive").gameObject;

        stateMachine = new EntityStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        workspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = workspace;
    }
}
