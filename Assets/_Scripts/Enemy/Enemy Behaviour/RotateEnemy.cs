using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    [SerializeField] private float changingInterval;
    private Vector3 _playerPos;
    public float ChangingInterval
    {
        get => changingInterval;
        set => changingInterval = Mathf.Sign(value);
    }

    private EnemyStateMachineMain _enemyStateMachine;
    private Transform _currentTransform;
    private Vector3 _currentScale;

    private void Start()
    {
        _currentTransform = GetComponent<Transform>();
        _currentScale = _currentTransform.localScale;
        _enemyStateMachine = GetComponentInParent<EnemyStateMachineMain>();
    }

    private void OnValidate()
    {
        ChangingInterval = changingInterval;
    }
    private void LateUpdate()
    {
        Flip();
    }
    
    private void Flip()
    {
        var enemyState = _enemyStateMachine.EnemyState.CurrentEnemyState as IEnemyState;
        if (enemyState != null)
        {
            UpdateDirectionBasedOnState(enemyState);
        }
    }

    private void UpdateDirectionBasedOnState(IEnemyState enemyState)
    {
        Vector3 direction = enemyState.RotateDirection();
        if (direction.x > 0)
        {
            _currentScale.x = Mathf.Abs(_currentScale.x) * ChangingInterval;
        }
        else if (direction.x < 0)
        {
            _currentScale.x = -Mathf.Abs(_currentScale.x) * ChangingInterval;
        }
        _currentTransform.localScale = _currentScale;
    }
}
