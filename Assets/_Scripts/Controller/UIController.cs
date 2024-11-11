using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private PlayerDamage _playerDamage;
    [HideInInspector] public Slider slider;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        _playerDamage = GetComponent<PlayerDamage>();
    }
    private void OnEnable()
    {
        panel.SetActive(true);
        slider.minValue = 0f;
        slider.maxValue = _playerDamage.hp;
        _playerDamage.CurrentHp = _playerDamage.hp;
        slider.value = slider.maxValue;
    }
    private void OnDisable()
    {
        int random=Random.Range(0,3);
        panel.SetActive(false);
    }
}
