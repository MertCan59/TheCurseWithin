using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CurrentPlayerState
{
    Warrior,
    Cursed
}
public class PlayerDamage : PlayerDamageObserver,IDamageable
{
    private UIController _uiController;
    private CurrentPlayerState _currentPlayerState;
    [SerializeField] private List<GameObject> playerActiveSpriteGo;
    public static bool CanReceiveDamage;
    protected override void Awake()
    {
        base.Awake();
      //  _slider = GetComponentInChildren<Slider>();
      _uiController = GetComponent<UIController>();
      CanReceiveDamage = true;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (playerActiveSpriteGo[1].activeInHierarchy)
        {
            StartCoroutine(test());
            Debug.Log("Cursed is active");
        }
    }

    public override void OnDamageTaken()
    {
        _uiController.slider.value = CurrentHp;
        if (CurrentHp <= 0)
        {
            isAlive = false;
            ChangeCurrentState();
        }
    }

    public void GetDamage(float amount)
    {
        var damage = amount;
        CurrentHp -= damage;
    }
    public void GetExtraDamage(float amount)
    {
        var damage = amount;
        CurrentHp -= damage*1.25f;
    }
    private void ChangeCurrentState()
    {
        var previousState = _currentPlayerState;
        if (isAlive)
        {
            _currentPlayerState = CurrentPlayerState.Warrior;
            CurrentHp = hp;
            playerActiveSpriteGo[0].SetActive(true);
            playerActiveSpriteGo[1].SetActive(false);
        }
        else
        {
            _currentPlayerState = CurrentPlayerState.Cursed;
            playerActiveSpriteGo[1].SetActive(true);
            playerActiveSpriteGo[0].SetActive(false);
        }
        if (_currentPlayerState != previousState)
        {
            ControlState();
        }
    }
    private void ControlState()
    {
        switch (_currentPlayerState)
        {
            case CurrentPlayerState.Warrior:
                _uiController.enabled=true;
                isAlive = true;
                CanReceiveDamage = true;
                break;
            case CurrentPlayerState.Cursed:
                _uiController.enabled = false;
                isAlive = false;
                CanReceiveDamage = false;
                break;
        }
    }
    IEnumerator test()
    { 
        yield return new WaitForSeconds(1.5f);
        _currentPlayerState = CurrentPlayerState.Warrior; 
        ControlState();
        ChangeCurrentState();
        yield return new WaitForSeconds(1.5f);
        CanReceiveDamage = true;
    }
}
