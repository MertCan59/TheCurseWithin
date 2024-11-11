using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;
public class CastSpell : MonoBehaviour
{
    [SerializeField] [CanBeNull] private List<GameObject>  spellGameobject;
    [SerializeField] private Transform instantiatePosition;
    private Vector2 _initialPos;
    [SerializeField] private Animator[] attackAnimations;

    public void InstantiateSpell()
    {
        StartCoroutine(AttackStart());
    }

    private IEnumerator AttackStart()
    {
        _initialPos = instantiatePosition.position;
        int randomSpell = Random.Range(0, spellGameobject.Count);
        foreach (var animations in attackAnimations)
        {
            float animationLength = animations.GetCurrentAnimatorStateInfo(0).length;
            float castTime = animationLength * 0.35f;
            yield return new WaitForSeconds(castTime);
            var go = Instantiate(spellGameobject[randomSpell], _initialPos, Quaternion.identity);
        }
    }
}