using System;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarUI : EnemyDamageObserver
{ 
    public override void OnDamageTaken()
    {
       Debug.Log("Hello world");
    }
}
