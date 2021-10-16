using UnityEngine;
using UnityEngine.Events;

public class CoinDestroy : MonoBehaviour
{
    public static event UnityAction<Vector3> OnDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            OnDestroyed(transform.position);
            Destroy(gameObject);
        }     
    }
}
