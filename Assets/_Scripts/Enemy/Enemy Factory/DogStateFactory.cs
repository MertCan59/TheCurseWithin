using UnityEngine;

public class DogStateFactory : EnemyStateFactory
{
    public override EnemyIdleState CreateIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed)
    {
        return new DogIdleState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed);
    }

    public override EnemyMoveState CreateMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed)
    {
        return new DogMoveState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed);
    }

    public override EnemyAttackState CreateAttackState(EnemyStateMachineMain enemyStateController, EnemyState state,
        GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, Animator animator,
        float speed)
    {
        return new DogAttackState(enemyStateController, state, enemyGameobject, followTarget, rgb, layer,animator, speed);
    }
}
