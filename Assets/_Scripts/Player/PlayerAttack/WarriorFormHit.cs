using UnityEngine;

public class WarriorFormHit:ICharacterHit
{
    public void OnHitEvent()
    {
        Debug.Log("Warrior hit");
    }
}
