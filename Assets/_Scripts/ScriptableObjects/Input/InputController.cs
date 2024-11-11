using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputController", menuName = "Scriptable Objects/InputController")]
public class InputController : ScriptableObject,PlayerInput.IPlayerActions
{
    [SerializeField] private PlayerInput _playerInput;

    #region Input_Control_Region
    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.SetCallbacks(this);
            SetPlayerInput();
        }
    }
    private void OnDisable()
    {
        DisableInput();
    }
    
    private void SetPlayerInput()
    {
        _playerInput.Player.Enable();
    }

    private void DisableInput()
    {
        _playerInput.Player.Disable();
    }
    #endregion

    #region Event_Region
    public event Action<Vector2> MoveEvent;
    public static event Action AttackEvent;
    
    //public event Action SprintEvent;

    #endregion
    
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    //May be added
    /*public void OnSprint(InputAction.CallbackContext context)
    {
        SprintEvent?.Invoke();
    }*/
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        AttackEvent?.Invoke();
    }
}
