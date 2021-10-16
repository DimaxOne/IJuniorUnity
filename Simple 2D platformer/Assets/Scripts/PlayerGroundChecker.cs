using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerJumper _playerJump;

    public bool OnGroung { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
       OnGroung = collision.TryGetComponent<Platforms>(out Platforms platforms);
        if (OnGroung)
            _playerJump.IsJump = false;
    }
}
