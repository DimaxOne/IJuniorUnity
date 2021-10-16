using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerGroundChecker _groundChecker;
    [SerializeField] private float _jumpMoveForce;

    private Rigidbody2D _rigidbody2D;

    public bool IsJump;
    
    public static class AnimatorKnight_Player
    {
        public static class Parameters
        {
            public const string JumpForce = nameof(JumpForce);
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _groundChecker.OnGroung && !IsJump)
        {
            IsJump = true;
            if(transform.localScale.x > 0)
                _rigidbody2D.AddForce(new Vector2(_jumpMoveForce, _jumpForce));
            if(transform.localScale.x < 0)
                _rigidbody2D.AddForce(new Vector2(_jumpMoveForce * -1, _jumpForce));
            _animator.SetFloat(AnimatorKnight_Player.Parameters.JumpForce, _jumpForce);
        }
        else
            _animator.SetFloat(AnimatorKnight_Player.Parameters.JumpForce, 0);
    }
}
