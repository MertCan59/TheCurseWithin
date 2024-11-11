using UnityEngine;

public class DeceasedIdleState : EnemyIdleState,IEnemyState
{
    public DeceasedIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer,float speed) : base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer,speed)
    {}
    private float _timer;
    private ICameraController _cameraController;
    public override void OnEnter()
    {
        base.OnEnter();
        _cameraController = new CameraController();
        _timer = 0f;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        _timer += Time.deltaTime;
        if (CameraController.CheckInCamera(Coll,Camerafrustum,Camera,IsCameraIn)&& _timer >= 2.5f) 
        {
            //State.ChangeState(EnemyStateController.EnemyAttackState);
        }
        if(!CameraController.CheckInCamera(Coll,Camerafrustum,Camera,IsCameraIn))
        {
            State.ChangeState(EnemyStateController.EnemyMoveState);
        }
    }
}
