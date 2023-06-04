using Enemies.States.SuperState;
using UnityEngine;

namespace Enemies.States.SubState
{
    public class E1_DeadState : DeadState
    {
        private Enemy1 enemy1;
        private GameObject effect;
        public E1_DeadState(GameObject effect, Entity entity, EnemyStateMachine stateMachine, Enemy1 enemy1, string animBoolName) : base(entity, stateMachine, animBoolName)
        {
            this.enemy1 = enemy1;
            this.effect = effect;
        }

        public override void Enable()
        {
            base.Enable();
            
            StateMachine.ChangeState(enemy1.IdleState);
        }

        public override void Enter()
        {
            base.Enter();

            GameObject.Instantiate(effect, enemy1.transform.position, Quaternion.identity);
        }
    }
}