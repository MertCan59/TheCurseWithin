using UnityEngine;
public abstract class EnemyStateFactory
{
    public abstract EnemyIdleState CreateIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed);
    public abstract EnemyMoveState CreateMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed);
    public abstract EnemyAttackState CreateAttackState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, Animator animator,float speed);
}
