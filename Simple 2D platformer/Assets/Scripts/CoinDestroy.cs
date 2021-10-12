using UnityEngine;
using UnityEngine.Events;

public class CoinDestroy : MonoBehaviour
{
    public delegate void Destroyed(Vector3 position);
    public static event Destroyed CoinDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            CoinDestroyed(gameObject.transform.position);
            Destroy(gameObject);
        }     
    }
}
