using System.Collections;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [Header("Animation Control")]
    private EnemyStateMachine _stateMachine;
    private EnemyStateMachineMain _stateMachineMain; // Cache the component
    private AnimationPlayer _animationPlayer;
    private Animator _animator;
    [SerializeField] private string idleHashString; 
    [SerializeField] private string runHashString;
    [SerializeField] private string attackHashString;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _stateMachineMain = GetComponentInParent<EnemyStateMachineMain>(); // Cache the component
        _stateMachine = _stateMachineMain.EnemyState.CurrentEnemyState; // Initialize the current state
        // Initialize the AnimationPlayer based on the current state
        _animationPlayer = new AnimationPlayer(_animator, _stateMachine, idleHashString, runHashString,attackHashString);
        _animationPlayer.OnEnable();
    }
    private void Update()
    {
        // Check if the state has changed
        var newStateMachine = _stateMachineMain.EnemyState.CurrentEnemyState;// Use the cached component
        if (newStateMachine != _stateMachine)
        {
            _stateMachine = newStateMachine;
            _animationPlayer = new AnimationPlayer(_animator, _stateMachine, idleHashString, runHashString,attackHashString);
            
            _animationPlayer.OnEnable();
        }
    }
    private void OnDisable()
    {
        if (_animationPlayer is not null)
        {
            _animationPlayer.OnDisable();
        }
    }
}
