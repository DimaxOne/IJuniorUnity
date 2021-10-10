using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerJump _playerJump;

    public bool OnGroung { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
       OnGroung = collision.TryGetComponent<Platforms>(out Platforms platforms);
        if (OnGroung)
            _playerJump.ChangeJumpStatus(false);
    }
}
