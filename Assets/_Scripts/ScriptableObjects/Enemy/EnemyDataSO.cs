using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Scriptable Objects/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public float maxHp;
    [HideInInspector] public float currentHp;
    public int defence;
    public int attackPower;
    public int magicPower;

    private void OnEnable()
    {
        currentHp = maxHp;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
    }
}
