using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealhBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _duration;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaximumHealth;
        _slider.minValue = _player.MinimumHealth;
        _slider.value = _player.CurrentHealth;
        _duration = 10f;
    }

    private void Update()
    {
        if (_slider.value == _player.CurrentHealth)
            return;
        else
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentHealth, _duration * Time.deltaTime);  
    }
}
