using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerLevelDataSO")]
public class PlayerLevelDataSO : ScriptableObject
{
    private const float MaxLevel = 99;
    private const float PlayerLevel = 1;
    private const float CurrentExp = 0;
    private const int ExperienceToNextLevel = 100;
    private const float StatIncreaseRate = 1.1f;
    public float playerLevel;
    public float currentExp;
    public int experienceToNextLevel;
    public float experienceIncreaseRate;
    public float statIncreaseRate;
    public event Action LeveLUpAction;
    public event Action StatIncreaseAction;
    private void OnEnable()
    {
        playerLevel = PlayerLevel;
        currentExp = CurrentExp;
        experienceToNextLevel = ExperienceToNextLevel;
        statIncreaseRate = StatIncreaseRate;
    }
    public void GainExperience(float amount)
    {
        float expAmount = amount;
        currentExp += expAmount;
        if(currentExp >= experienceToNextLevel)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        LeveLUpAction?.Invoke();
        playerLevel = Mathf.Clamp(playerLevel,1f,MaxLevel);
        StatIncrease();
    }
    private void StatIncrease()
    {
        StatIncreaseAction?.Invoke();
    }
}