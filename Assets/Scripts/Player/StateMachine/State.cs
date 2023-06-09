using UnityEngine;

public class State
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;
    private string animBoolName;

    public State(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
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
    }

    public virtual void PhysicUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
    }

    public virtual void StateOnTriggerEnter(Collider2D other)
    {
    }
}