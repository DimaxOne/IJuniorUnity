using UnityEngine;
using UnityEngine.Events;

public class CoinDestroyer : MonoBehaviour
{
    public static event UnityAction<Vector3> Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            Destroyed?.Invoke(transform.position);
            Destroy(gameObject);
        }     
    }
}
