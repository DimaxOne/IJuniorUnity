using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealhBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _duration;
    private bool _isValueChange;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaximumHealth;
        _slider.minValue = _player.MinimumHealth;
        _slider.value = _player.CurrentHealth;
        _duration = 10f;
    }

    private void OnEnable()
    {
        ButtonAction.ChangedHealth += ChangeValue;
    }

    private void OnDisable()
    {
        ButtonAction.ChangedHealth -= ChangeValue;
    }

    private void Update()
    {
        if(_isValueChange)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentHealth, _duration * Time.deltaTime);
            if (_slider.value == _player.CurrentHealth)
                _isValueChange = false;
        }  
    }

    private void ChangeValue()
    {
        _isValueChange = true;
    }
}
