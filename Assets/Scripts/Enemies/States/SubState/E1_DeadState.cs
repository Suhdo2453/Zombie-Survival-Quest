using Enemies.States.SuperState;
using UnityEngine;

namespace Enemies.States.SubState
{
    public class E1_DeadState : DeadState
    {
        public E1_DeadState(Entity entity, EnemyStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
        {
        }
    }
}