using UnityEngine;

public class Player : MonoBehaviour
{
    private float _shiftHealth;
    private float _duration;
    private float _maximumHealth;
    private float _minimumHealth;
    private bool _isButtonDownClick;
    private bool _isButtonUpClick;
    private bool _isDead;
    private float _currentHealth;
    private float _temporaryHealth;

    public float MaximumHealth => _maximumHealth;
    public float MinimumHealth => _minimumHealth;
    public float CurrentHealth => _currentHealth;

    public void OnButtonUpClick()
    {
        if (!_isButtonDownClick && !_isButtonUpClick && !_isDead)
        {
            _temporaryHealth = _currentHealth;
            _isButtonUpClick = true;
        }
    }

    public void OnButtomDownClick()
    {
        if (!_isButtonDownClick && !_isButtonUpClick && !_isDead)
        {
            _temporaryHealth = _currentHealth;
            _isButtonDownClick = true;
        }
    }

    private void Start()
    {
        _shiftHealth = 10f;
        _duration = 10f;
        _maximumHealth = 120;
        _minimumHealth = 0;
        _currentHealth = 100f;
        _isButtonDownClick = false;
        _isButtonUpClick = false;
        _isDead = false;
    }

    private void Update()
    {
        if (_isButtonUpClick)
        {
            if (_temporaryHealth < _maximumHealth)
            {
                if (_shiftHealth + _temporaryHealth > _maximumHealth)
                {
                    _currentHealth = Mathf.MoveTowards(_temporaryHealth, _maximumHealth, _duration * Time.deltaTime);
                    if (_currentHealth == _maximumHealth)
                        _isButtonUpClick = false;
                }
                else
                {
                    _currentHealth = Mathf.MoveTowards(_currentHealth, _temporaryHealth + _shiftHealth, _duration * Time.deltaTime);
                    if (_currentHealth == _temporaryHealth + _shiftHealth)
                        _isButtonUpClick = false;
                }
            }
            if (_currentHealth == _maximumHealth)
            {
                Debug.Log("Персонаж здоров");
                _isButtonUpClick = false;
            }
        }

        if (_isButtonDownClick)
        {
            if (_temporaryHealth > _minimumHealth)
            {
                _currentHealth = Mathf.MoveTowards(_currentHealth, _temporaryHealth - _shiftHealth, _duration * Time.deltaTime);
                if (_currentHealth == _temporaryHealth - _shiftHealth)
                    _isButtonDownClick = false;
            }
            if (_currentHealth <= _minimumHealth)
            {
                _isDead = true;
                Debug.Log("Персонаж мертв");
            }
        }
    }
}
