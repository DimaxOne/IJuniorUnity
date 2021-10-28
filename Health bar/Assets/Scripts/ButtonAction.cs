using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnButtonUpClick()
    {
        _player.GetHealth();
    }

    public void OnButtonDownClick()
    {
        _player.GetDamage();
    }
}
