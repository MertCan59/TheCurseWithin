using JetBrains.Annotations;
using UnityEngine;

public enum EnemyType
{
    Mummy,
    Mage,
    Dog
}
public class EnemyStateMachineMain : MonoBehaviour
{
    [Header("Move")] 
    [SerializeField] private float speed;
    
    [Header("Main Object controlling")]
    private Rigidbody2D _rigidbody2D;
    private GameObject _enemyGameobject;
    private GameObject _player;
    private Animator _animator;
    [Header("Raycast Controls")] 
    [SerializeField] private LayerMask layer;
    [CanBeNull] public Transform hyenaAttackPos;
    public EnemyType enemyType;

    [Header("State Controls")] 
    public EnemyState EnemyState;
    public EnemyIdleState EnemyIdleState;
    public EnemyMoveState EnemyMoveState;
    public EnemyAttackState EnemyAttackState;
    
    private EnemyStateFactory _enemyStateFactory;
    public void Awake()
    {
        EnemyState = new EnemyState();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        _enemyGameobject = gameObject;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        switch (enemyType)
        {
            case EnemyType.Mummy:
                _enemyStateFactory = new MummyStateFactory();
                break;
            case EnemyType.Mage:
                _enemyStateFactory = new MageStateFactory();
                break;
            case EnemyType.Dog:
                _enemyStateFactory= new DogStateFactory();
                break;
        }
        GetIdleState();
        GetMoveState();
        GetAttackState();
        EnemyState.StartState(EnemyIdleState);
    }
    public void Update()
    {
        EnemyState.CurrentEnemyState.OnUpdate();

    }
    public void FixedUpdate()
    {
        EnemyState.CurrentEnemyState.OnFixedUpdate();
    }
    private void GetIdleState()
    {
        EnemyIdleState = _enemyStateFactory.CreateIdleState(this, EnemyState, _enemyGameobject, _player, _rigidbody2D, layer, speed);
    }
    private void GetMoveState()
    {
        EnemyMoveState = _enemyStateFactory.CreateMoveState(this, EnemyState, _enemyGameobject, _player, _rigidbody2D, layer, speed);
    }
    private void GetAttackState()
    {
       EnemyAttackState=_enemyStateFactory.CreateAttackState(this, EnemyState, _enemyGameobject, _player, _rigidbody2D, layer, _animator,speed);
    }
}
