using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage :MonoBehaviour,ITakeDamage
{
    private readonly List<IPlayerDamageObserver> _playerDamageObservers = new List<IPlayerDamageObserver>();
    public void AddEnemyObserver(IPlayerDamageObserver playerDamageObserver)
    {
        _playerDamageObservers.Add(playerDamageObserver);
    }
    public void RemoveEnemyObserver(IPlayerDamageObserver playerDamageObserver)
    {
        _playerDamageObservers.Remove(playerDamageObserver);
    }
    public void TakeDamage()
    {
        if (_playerDamageObservers != null)
        {
            var observersCopy = new List<IPlayerDamageObserver>(_playerDamageObservers);
            foreach (var observer in observersCopy)
            {
                observer?.OnDamageTaken();
            }
        }
    }
}
