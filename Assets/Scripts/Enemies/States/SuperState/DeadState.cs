using System.Net.Http.Headers;
using UnityEngine;

namespace Enemies.States.SuperState
{
    public class DeadState : EnemyState
    {
        public DeadState(Entity entity, EnemyStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            Entity.gameObject.SetActive(false);
        }
    }
}