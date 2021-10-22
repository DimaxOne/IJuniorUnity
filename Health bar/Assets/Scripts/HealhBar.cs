using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealhBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaximumHealth;
        _slider.minValue = _player.MinimumHealth;
        _slider.value = _player.CurrentHealth;
    }

    private void Update()
    {
        _slider.value = _player.CurrentHealth;
    }
}
