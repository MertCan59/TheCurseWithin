using UnityEngine;

public abstract class EnemyStateMachine
{
    protected readonly EnemyStateMachineMain EnemyStateController;
    protected readonly GameObject FollowTarget;
    protected readonly GameObject EnemyGameobject;
    protected EnemyState State;
    protected ICameraController CameraController;
    protected new Rigidbody2D  Rigidbody2D;
    protected LayerMask Layer;
    protected Plane[] Camerafrustum;
    protected Camera Camera;
    protected Collider2D Coll;
    protected bool IsCameraIn;
    protected float Speed;
    public Vector3 Direction;
    public bool IsMoving;
    public bool CanMove;
    public bool IsAttacking;

    [Range(-1, 1)] private float _rayOriginInterval;
    protected EnemyStateMachine(EnemyStateMachineMain enemyStateController, EnemyState state,GameObject enemyGameobject ,GameObject followTarget,
        Rigidbody2D rgb,LayerMask layer,float speed)
    {
        EnemyStateController = enemyStateController;
        State = state;
        FollowTarget = followTarget;
        EnemyGameobject = enemyGameobject;
        Rigidbody2D = rgb;
        Layer = layer;
        Speed = speed;
    }

    public virtual void OnEnter()
    {
        CameraController = new CameraController();
        Rigidbody2D = EnemyGetComponent<Rigidbody2D>();
        Camera = Camera.main;
        Coll = EnemyGetComponent<Collider2D>();
    }
    public virtual void OnUpdate()
    {}
    public virtual void OnFixedUpdate()
    {} 
    public virtual void OnExit(){} 
    protected T EnemyGetComponent<T>() where T : Component
    {
        T component = EnemyGameobject.GetComponent<T>();
        if (component == null)
        {
            component = EnemyGameobject.GetComponentInChildren<T>();
        }
        return component;
    }

    protected T PlayerGetComponent<T>() where T : Component
    {
        T component = FollowTarget.GetComponent<T>();
        if (component == null)
        {
            component = FollowTarget.GetComponentInChildren<T>();
        }
        return component;
    }
}
