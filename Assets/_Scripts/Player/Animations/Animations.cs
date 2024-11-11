using UnityEngine;

public class Animations : MonoBehaviour
{
    private WarriorAnimatorController _warriorAnimatorController;
    private CursedFormAnimationController _cursedFormAnimationController;
    [SerializeField] private Animator warriorAnimator;
    [SerializeField] private Animator cursedFormAnimator;
    private void Start()
    {
        _warriorAnimatorController = new WarriorAnimatorController(warriorAnimator);
        _cursedFormAnimationController = new CursedFormAnimationController(cursedFormAnimator);
        _warriorAnimatorController.OnEnable(); 
        _cursedFormAnimationController.OnEnable();
    }
    private void OnDisable()
    {
        _warriorAnimatorController.OnDisable();
        _cursedFormAnimationController.OnDisable();
    }
}