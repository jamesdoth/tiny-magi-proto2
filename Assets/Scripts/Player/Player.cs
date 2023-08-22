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
    public int FacingDirection { get; private set; }

    private Camera mainCam;
    private Vector2 mousePos;
    private Vector3 worldMousePos;

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
        FacingDirection = 1;

        GameObject mainCamObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (mainCamObject != null)
        {
            mainCam = mainCamObject.GetComponent<Camera>();
        }
        else
        {
            Debug.LogError("Main camera not found in the scene.");
        }

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        worldMousePos = mainCam.ScreenToWorldPoint(mousePos);

        Vector3 playerPosition = transform.position;
        Debug.Log("Player Position: " + playerPosition);

        float mouseXDiff = mousePos.x - transform.position.x;
        Debug.Log(mouseXDiff);


        if (mouseXDiff > 0 && FacingDirection == -1)
        {
            Flip();
        }
        else if (mouseXDiff < 0 && FacingDirection == 1)
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

    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
