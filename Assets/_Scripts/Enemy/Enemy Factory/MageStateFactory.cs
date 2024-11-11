using UnityEngine;

public class MageStateFactory : EnemyStateFactory
{
    public override EnemyIdleState CreateIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed)
    {
        return new DeceasedIdleState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed);
    }

    public override EnemyMoveState CreateMoveState(EnemyStateMachineMain enemyStateController, EnemyState state,
        GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed)
    {
        return new DeceasedMoveState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed);
    }

    public override EnemyAttackState CreateAttackState(EnemyStateMachineMain enemyStateController, EnemyState state,
        GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer,Animator animator ,float speed)
    {
        return new DeceasedAttackState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer,animator, speed);
    }
}
