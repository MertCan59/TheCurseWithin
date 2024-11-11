using System.Collections;
using UnityEngine;
public class EnemyFlashEffect:EnemyDamageObserver
{
    private static readonly int FlashColorID = Shader.PropertyToID("_FlashColor");
    private static readonly int FlashAmountID = Shader.PropertyToID("_FlashAmount");
    private SpriteRenderer _spriteRenderer;
    private Material _material;
    [ColorUsage(true,true)]
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashTime = 0.25f;
    [SerializeField] private Material enemyMaterial;
    [SerializeField] private AnimationCurve flashSpeedCurve;
    
    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Init();
    }
    public override void OnDamageTaken()
    { 
        StartCoroutine(DamageFlash());
    }
    
    private void Init()
    {
        _material = new Material(enemyMaterial);
        _material = _spriteRenderer.material;
    }

    private IEnumerator DamageFlash()
    {
        SetFlashColor();
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1f, flashSpeedCurve.Evaluate(elapsedTime), (elapsedTime / flashTime));
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }
    }
    private void SetFlashColor()
    {
        _material.SetColor(FlashColorID, flashColor);
    }

    private void SetFlashAmount(float amount)
    {
        _material.SetFloat(FlashAmountID, amount);
    }
}
