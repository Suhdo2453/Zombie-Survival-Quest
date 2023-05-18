using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerKnockBackState KnockBackState {get; private set; }

    [SerializeField] private PlayerData PlayerData;
    [SerializeField] private Weapon_gun_01 weapon;

    public Rigidbody2D RB;
    public Animator Anim;
    public InputHandler InputHandler { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    public Vector2 workSpaceVector;
    
    private SpriteRenderer spriteRenderer;
    public bool isKnockBack { get; set; }


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idleState");
        MoveState = new PlayerMoveState(this, StateMachine, PlayerData, "moveState");
        KnockBackState = new PlayerKnockBackState(this, StateMachine, PlayerData, "knockBack");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<InputHandler>();
        RB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        FacingDirection = 1;


        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicUpdate();
        FacingToMouse();
    }

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocity(Vector2 velocity)
    {
        workSpaceVector = velocity;
        RB.velocity = workSpaceVector;
        CurrentVelocity = workSpaceVector;
    }

    public void CheckIfShouldFlip(Vector2 inputDirection)
    {
        if (inputDirection != Vector2.zero && RoundFloat(inputDirection.x) == -FacingDirection)
            Flip();
    }

    public void FacingToMouse()
    {
        if ((InputHandler.MousePosition.x < transform.position.x)&& FacingDirection==1)
        {
            // Lật player sang trái
            Flip();
        }
        else if ((InputHandler.MousePosition.x > transform.position.x)&& FacingDirection==-1)
        {
            // Lật player sang phải
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180f, 0.0f);
    }

    public static int RoundFloat(float num)
    {
        return num > 0 ? Mathf.CeilToInt(num) : Mathf.FloorToInt(num);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StateMachine.currentState.StateOnTriggerEnter(other);
        if (!other.transform.CompareTag("Enemy") || isKnockBack) return;
        
        IEnumerator TakeDamageCor()
        {
            spriteRenderer.material.SetInt("_Hit", 1);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.material.SetInt("_Hit", 0);
        }
        
        if(gameObject.activeSelf) StartCoroutine(TakeDamageCor());
        
        PlayerStats.Instance.DecreaseHealth();
        
        StateMachine.ChangeState(KnockBackState);
    }
    
    
}