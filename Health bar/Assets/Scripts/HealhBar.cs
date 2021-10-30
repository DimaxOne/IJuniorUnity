using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealhBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _waitingSeconds;

    private Slider _slider;
    private float _duration;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaximumHealth;
        _slider.minValue = _player.MinimumHealth;
        _slider.value = _player.CurrentHealth;
        _duration = 1f;
    }

    private void OnEnable()
    {
        _player.ChangedHealth += ChangeValue;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= ChangeValue;
    }

    private void ChangeValue()
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        WaitForSeconds _waitingTime = new WaitForSeconds(_waitingSeconds);

        while (_slider.value != _player.CurrentHealth)  
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentHealth, _duration);
            yield return _waitingTime;
        }  
    }    
}
