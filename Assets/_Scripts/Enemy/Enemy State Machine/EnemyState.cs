public class EnemyState
{
    public EnemyStateMachine CurrentEnemyState { get;private set; }

    public void StartState(EnemyStateMachine stateMachine)
    {
        CurrentEnemyState = stateMachine;
        CurrentEnemyState.OnEnter();
    }

    public void ChangeState(EnemyStateMachine stateMachine)
    {
        CurrentEnemyState.OnExit();
        CurrentEnemyState = stateMachine;
        CurrentEnemyState.OnEnter();
    }
}
