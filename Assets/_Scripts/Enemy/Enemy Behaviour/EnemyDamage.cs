using UnityEngine;
using UnityEngine.UI;
public class EnemyDamage : EnemyDamageObserver,IDamageable
{
    [SerializeField] private PlayerLevelDataSO playerLevelDataSo;
    private PlayerLevelDataSO _copyData;
    [SerializeField] private float expAmount;
    private Slider _slider;
    protected override void Awake()
    {
        base.Awake();
        _slider = GetComponentInChildren<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = hp;
        _slider.value = _slider.maxValue;
    }
    public override void OnDamageTaken()
    {
        _slider.value = CurrentHp;
        if (CurrentHp <= 0)
        {
            playerLevelDataSo.GainExperience(expAmount);
            Destroy(gameObject);
        } 
    }
    public void GetDamage(float amount)
    {
        DamageAmount = amount;
        CurrentHp-= DamageAmount;
    }
    public void GetExtraDamage(float amount)
    {
        DamageAmount = amount;
        CurrentHp -= DamageAmount;
    }
}
