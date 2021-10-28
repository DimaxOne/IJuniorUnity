using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _shiftHealth;
    private float _maximumHealth;
    private float _minimumHealth;
    private bool _isDead;
    private float _currentHealth;

    public event UnityAction ChangedHealth;

    public float MaximumHealth => _maximumHealth;
    public float MinimumHealth => _minimumHealth;
    public float CurrentHealth => _currentHealth;

    public void GetHealth()
    {
        if (!_isDead && _currentHealth != _maximumHealth)
        {
            if (_currentHealth + _shiftHealth <= _maximumHealth)
                _currentHealth += _shiftHealth;
            else 
                _currentHealth = _maximumHealth;

            ChangedHealth?.Invoke();
        }
        else
        {
            if (_isDead)
                Debug.Log("Персонаж мертв.");
            else
                Debug.Log("Персонаж здоров.");
        }   
    }

    public void GetDamage()
    {
        if (!_isDead && _currentHealth != _minimumHealth)
        {
            if (_currentHealth - _shiftHealth > _minimumHealth)
            {
                _currentHealth -= _shiftHealth;
            } 
            else
            {
                _currentHealth = _minimumHealth;
                _isDead = true;
                Debug.Log("Персонаж погиб.");
            }

            ChangedHealth?.Invoke();
        }
        else
        {
            Debug.Log("Персонаж мертв.");
        }  
    }

    private void Start()
    {
        _shiftHealth = 10f;
        _maximumHealth = 120;
        _minimumHealth = 0;
        _currentHealth = 100f;
        _isDead = false;
    }
}
