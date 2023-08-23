using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public Animator Anim { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    private Vector2 workspace;
    public Vector2 CurrentVelocity { get; private set; }
    private bool FacingRight;
    private Vector3 mousePos;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();

        FacingRight = true;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (mousePos.x > transform.position.x && !FacingRight)
        {
            Flip();
        }
        else if (mousePos.x < transform.position.x && FacingRight)
        {
            Flip();
        }

        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
