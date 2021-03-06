using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinDestroyer _coinPrefab;
    [SerializeField] private Transform _coinsSpawn;

    private Transform[] _coinSpawnPosition;

    private void Awake()
    {
        _coinSpawnPosition = new Transform[_coinsSpawn.childCount];

        for (int i = 0; i < _coinsSpawn.childCount; i++)
        {
            _coinSpawnPosition[i] = _coinsSpawn.GetChild(i);
            var coin = Instantiate(_coinPrefab, _coinSpawnPosition[i].position, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        CoinDestroyer.Destroyed += RespawnCoin;
    }

    private void OnDisable()
    {
        CoinDestroyer.Destroyed -= RespawnCoin;
    }

    private void RespawnCoin(Vector3 position)
    {
        StartCoroutine(Respawn(position));
    }

    private IEnumerator Respawn(Vector3 position)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(5);
        yield return waitForSeconds;
        var coin = Instantiate(_coinPrefab, position, Quaternion.identity);
    }
}
