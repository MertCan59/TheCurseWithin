using UnityEngine;

public class MummyStateFactory : EnemyStateFactory
{
    public override EnemyIdleState CreateIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed)
    {
        return new MummyIdleState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed);
     
    }

    public override EnemyMoveState CreateMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed)
    {
        return new MummyMoveState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed);
    }

    public override EnemyAttackState CreateAttackState(EnemyStateMachineMain enemyStateController, EnemyState state,
        GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, Animator animator,float speed)
    {
        return new MummyAttackState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer,animator, speed);
    }
}
