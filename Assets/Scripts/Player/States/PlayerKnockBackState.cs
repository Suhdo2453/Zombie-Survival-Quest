using System.Collections;
using UnityEngine;

public class PlayerKnockBackState : State
{
    private Vector2 knockBackDirection;

    public PlayerKnockBackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData,
        string animBoolName) : base(player,
        stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.isKnockBack = true;
    }

    public override void StateOnTriggerEnter(Collider2D other)
    {
        base.StateOnTriggerEnter(other);
        knockBackDirection = (player.transform.position - other.transform.position).normalized;
        ApplyKnockBack(knockBackDirection, playerData.knockBackForce, playerData.knockBackTime);
    }
    
    public void ApplyKnockBack(Vector2 knockBackDirection, float knockBackForce, float knockBackDuration)
    {
        player.SetVelocity(knockBackDirection * knockBackForce);

        player.StartCoroutine(EndKnockBackAfterDelay(knockBackDuration));
    }

    private IEnumerator EndKnockBackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        player.isKnockBack = false;
        stateMachine.ChangeState(player.IdleState);
    }
}