using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerGroundChecker _groundChecker;
    [SerializeField] private PlayerJumper _playerJump;

    private Rigidbody2D _rigidbody2D;
    private float _directionMovement;
    private Vector3 _startScale;
    private Vector3 _mirrowScale;

    public static class AnimatorKnight_Player
    {
        public static class Parameters
        {
            public const string Speed = nameof(Speed);
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startScale = transform.localScale;
        _mirrowScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void FixedUpdate()
    {
        _directionMovement = Input.GetAxis("Horizontal");

        if (_directionMovement > 0)
            transform.localScale = _startScale;
        if (_directionMovement < 0)
            transform.localScale = _mirrowScale;

        if (_directionMovement != 0 && _groundChecker.OnGroung && !_playerJump.IsJump)
        {
            _rigidbody2D.velocity = new Vector2(_directionMovement * _speed, 0);
        }
        _animator.SetFloat(AnimatorKnight_Player.Parameters.Speed, Mathf.Abs(_directionMovement));
    }
}
