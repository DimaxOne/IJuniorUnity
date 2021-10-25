using UnityEngine;
using UnityEngine.Events;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private Player _player;

    public static event UnityAction ChangedHealth;

    public void OnButtonUpClick()
    {
        _player.GetHealth();
        ChangedHealth?.Invoke();
    }

    public void OnButtonDownClick()
    {
        _player.GetDamage();
        ChangedHealth?.Invoke();
    }
}
