using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouseState : WeaponState
{
    private Vector2 mousePos;
    private Vector2 aimDir;
    private float aimAngle;
    private Player player;
    
    public LookAtMouseState(Player player, Weapon weapon, WeaponStateMachine stateMachine, string animBoolName) : base(weapon, stateMachine, animBoolName)
    {
        this.player = player;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        mousePos = InputHandler.Instance.MousePosition;
        aimDir = mousePos - (Vector2)weapon.transform.position;
        aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle));
        weapon.transform.rotation = rotation;
        Flip();
    }
    
    private void Flip()
    {
        weapon.transform.Rotate(player.FacingDirection == -1 ? 180 : 0, 0, 0);
    }
}
