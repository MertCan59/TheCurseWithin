using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyTakeDamage : MonoBehaviour,ITakeDamage
{
    private readonly List<IEnemyDamageObserver> _enemyDamageObservers = new List<IEnemyDamageObserver>();
    public void AddEnemyObserver(IEnemyDamageObserver damageObserver)
    {
        _enemyDamageObservers.Add(damageObserver);
    }
    public void RemoveEnemyObserver(IEnemyDamageObserver damageObserver)
    {
        _enemyDamageObservers.Remove(damageObserver);
    }
    public void TakeDamage()
    {
        if (_enemyDamageObservers != null)
        {
            var observersCopy = new List<IEnemyDamageObserver>(_enemyDamageObservers);
            foreach (var observer in observersCopy)
            {
                observer?.OnDamageTaken();
            }
        }
    }
}
