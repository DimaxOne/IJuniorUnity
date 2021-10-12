using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinsSpawn;

    private Transform[] _coinSpawnPosition;

    private void Start()
    {
        _coinSpawnPosition = new Transform[_coinsSpawn.childCount];

        for (int i = 0; i < _coinsSpawn.childCount; i++)
        {
            _coinSpawnPosition[i] = _coinsSpawn.GetChild(i);
        }

        StartCoroutine(SpawnCoins());
        CoinDestroy.CoinDestroyed += RespawnCoin;
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _coinSpawnPosition.Length; i++)
        {
            GameObject coin = Instantiate(_coinPrefab, _coinSpawnPosition[i].position, Quaternion.identity);
        }

        yield return null;
    }

    private void RespawnCoin(Vector3 position)
    {
        StartCoroutine(RespawnCoinCorutine(position));
    }

    private IEnumerator RespawnCoinCorutine(Vector3 position)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(10);
        yield return waitForSeconds;
        GameObject coin = Instantiate(_coinPrefab, position, Quaternion.identity);
    }
}
