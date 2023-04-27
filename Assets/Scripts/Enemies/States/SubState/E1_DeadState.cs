using Enemies.States.SuperState;
using UnityEngine;

namespace Enemies.States.SubState
{
    public class E1_DeadState : DeadState
    {
        private Enemy1 enemy1;
        public E1_DeadState(Entity entity, EnemyStateMachine stateMachine, Enemy1 enemy1, string animBoolName) : base(entity, stateMachine, animBoolName)
        {
            this.enemy1 = enemy1;
        }

        public override void Enable()
        {
            base.Enable();
            
            StateMachine.ChangeState(enemy1.IdleState);
        }
    }
}