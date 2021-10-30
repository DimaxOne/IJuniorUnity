using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maximumHealth;
    [SerializeField] private float _minimumHealth;

    private float _shiftHealth;
    private bool _isDead;
    private float _currentHealth;

    public event UnityAction ChangedHealth;

    public float MaximumHealth => _maximumHealth;
    public float MinimumHealth => _minimumHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _shiftHealth = 10f;
        _currentHealth = 100f;
        _isDead = false;
    }

    public void GetHealth()
    {
        if (!_isDead)
        {
            _currentHealth += Mathf.Clamp(_shiftHealth, _minimumHealth, _maximumHealth);
            ChangedHealth?.Invoke();
        }  
    }

    public void GetDamage()
    {
        if (!_isDead)
        {
            _currentHealth -= Mathf.Clamp(_shiftHealth, _minimumHealth, _maximumHealth);

            if (_currentHealth == _minimumHealth)
                _isDead = true;

            ChangedHealth?.Invoke();
        }  
    }
}
