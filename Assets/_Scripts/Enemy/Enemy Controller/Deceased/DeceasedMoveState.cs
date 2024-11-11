using UnityEngine;

public class DeceasedMoveState : EnemyMoveState,IEnemyState
{
    public DeceasedMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) 
        :
        base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {
        _speed = speed;
    }
    private const float DistanceThreshold = .1f;
    private readonly float _speed;
    private Transform _t;
    private Vector3 _movePos;
    private Vector3 _moveDirection;
    private Vector2 _screenBottomLeft;
    private Vector2 _screenTopRight;
    private ICameraController _cameraController;
    private bool _isCameraIn;
    
    public override void OnEnter()
    {
        base.OnEnter();
        _t = EnemyGetComponent<Transform>();
        _cameraController = new CameraController();
        _screenBottomLeft = Camera.ScreenToWorldPoint(new Vector3(0, 0, Camera.nearClipPlane));
        _screenTopRight = Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.nearClipPlane));
        float xPos = Random.Range(_screenBottomLeft.x, _screenTopRight.x);
        float yPos = Random.Range(_screenBottomLeft.y, _screenTopRight.y);
        _movePos = new Vector2(xPos, yPos);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Vector2.Distance(_t.position, _movePos) <= DistanceThreshold )
        {
            State.ChangeState(EnemyStateController.EnemyIdleState);
        }
        if(!_cameraController.CheckInCamera(Coll,Camerafrustum,Camera,IsCameraIn))
        {
            State.ChangeState(this);
        }
    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        float speed = _speed * Time.fixedDeltaTime;
        if (IsMoving && CanMove) 
        {
            _moveDirection=(_movePos - Rigidbody2D.transform.position).normalized;
            
            Rigidbody2D.MovePosition(Rigidbody2D.transform.position + _moveDirection * speed);
        }   
    }
    public Vector3 RotateDirection()
    {
        UpdateDirection(_moveDirection);
        return Direction;
    }
}
