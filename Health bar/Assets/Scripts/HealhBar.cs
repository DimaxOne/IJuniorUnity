using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealhBar : MonoBehaviour
{
    private Slider _slider;
    private float _shiftHealth;
    private float _duration;
    private float _maximumHealth;
    private float _minimumHealth;
    private bool _isButtonDownClick;
    private bool _isButtonUpClick;
    private bool _isDead;
    private float _currentHealthValue;

    public void OnButtonUpClick()
    {
        if (!_isButtonDownClick && !_isButtonUpClick && !_isDead)
        {
            _currentHealthValue = _slider.value;
            _isButtonUpClick = true;
        }
    }

    public void OnButtomDownClick()
    {
        if (!_isButtonDownClick && !_isButtonUpClick && !_isDead)
        {
            _currentHealthValue = _slider.value;
            _isButtonDownClick = true;
        }
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _shiftHealth = 10f;
        _duration = 10f;
        _slider.maxValue = _maximumHealth = 120;
        _slider.minValue = _minimumHealth = 0;
        _isButtonDownClick = false;
        _isButtonUpClick = false;
        _isDead = false;
    }

    private void Update()
    {
        if(_isButtonUpClick)
        {
            if (_slider.value < _maximumHealth)
            {
                if (_shiftHealth + _slider.value > _maximumHealth)
                {
                    _slider.value = Mathf.MoveTowards(_slider.value, _maximumHealth, _duration * Time.deltaTime);
                    if (_slider.value == _maximumHealth)
                        _isButtonUpClick = false;
                }
                else
                {
                    _slider.value = Mathf.MoveTowards(_slider.value, _currentHealthValue + _shiftHealth, _duration * Time.deltaTime);
                    if (_slider.value == _currentHealthValue + _shiftHealth)
                        _isButtonUpClick = false;
                }    
            }
            if (_slider.value == _maximumHealth)
            {
                Debug.Log("Персонаж здоров");
                _isButtonUpClick = false;
            } 
        }

        if (_isButtonDownClick)
        {
            if (_slider.value > _minimumHealth)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _currentHealthValue - _shiftHealth, _duration * Time.deltaTime);
                if (_slider.value == _currentHealthValue - _shiftHealth)
                    _isButtonDownClick = false;
            }
            if (_slider.value <= _minimumHealth)
            {
                _isDead = true;
                Debug.Log("Персонаж мертв");
            }
        }
    }
}
