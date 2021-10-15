using UnityEngine;
using UnityEngine.Events;

public class CoinDestroy : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> _coinDestroyed;

    public event UnityAction<Vector3> OnDestroyed
    {
        add => _coinDestroyed.AddListener(value);
        remove => _coinDestroyed.RemoveListener(value);
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _coinDestroyed?.Invoke(transform.position);
            Destroy(gameObject);
        }     
    }
}
