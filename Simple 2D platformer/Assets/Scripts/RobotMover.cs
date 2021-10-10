using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RobotMover : MonoBehaviour
{
    [SerializeField] private Transform _rayDuration;
    [SerializeField] private float _speed;

    private RaycastHit2D _rayCastHit;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startScale;
    private Vector3 _mirrowScale;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //_startScale = transform.localScale;
        //_mirrowScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rayCastHit = Physics2D.Raycast(_rayDuration.position, _rayDuration.transform.up * -1, 2f);
        if (_rayCastHit)
            _rigidbody2D.velocity = Vector2.right * _speed;
        else
            Flip();
    }

    private void Flip()
    {
        _speed *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
