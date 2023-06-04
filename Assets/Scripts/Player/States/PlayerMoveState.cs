using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //player.CheckIfShouldFlip(player.InputHandler.RawMovementInput);
        player.SetVelocity(playerData.movementSpeed * InputHandler.Instance.RawMovementInput);
        if (InputHandler.Instance.RawMovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }
}
