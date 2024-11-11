using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public PlayerLevelDataSO playerLevelDataSo;
    public float attackPower;
    public float defence;
    public float magicPower;

    private void OnEnable()
    { 
        playerLevelDataSo.LeveLUpAction += PlayerLevelDataUpdate;
        playerLevelDataSo.StatIncreaseAction += PlayerStatDataUpdate;
    }

    private void OnDisable()
    {
        playerLevelDataSo.LeveLUpAction -= PlayerLevelDataUpdate;
        playerLevelDataSo.StatIncreaseAction -= PlayerStatDataUpdate;
    }

    private void PlayerLevelDataUpdate()
    {
        playerLevelDataSo.playerLevel++;
        Debug.Log($"Level up! New level {playerLevelDataSo.playerLevel},Damage: {attackPower}, Defense: {defence}, Magic Power: {magicPower}");

        playerLevelDataSo.currentExp = 0;
        playerLevelDataSo.experienceToNextLevel += (int)(playerLevelDataSo.experienceToNextLevel * playerLevelDataSo.experienceIncreaseRate);
    }

    private void PlayerStatDataUpdate()
    {
        attackPower += playerLevelDataSo.statIncreaseRate;
        defence += playerLevelDataSo.statIncreaseRate;
        magicPower += playerLevelDataSo.statIncreaseRate;
    }
}
