using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinsSpawn;

    private Transform[] _coinSpawnPosition;

    private void Awake()
    {
        _coinSpawnPosition = new Transform[_coinsSpawn.childCount];

        for (int i = 0; i < _coinsSpawn.childCount; i++)
        {
            _coinSpawnPosition[i] = _coinsSpawn.GetChild(i);
            GameObject coin = Instantiate(_coinPrefab, _coinSpawnPosition[i].position, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        CoinDestroy.OnDestroyed += RespawnCoin;
    }

    private void OnDisable()
    {
        CoinDestroy.OnDestroyed -= RespawnCoin;
    }

    private void RespawnCoin(Vector3 position)
    {
        StartCoroutine(RespawnCoinCorutine(position));
    }

    private IEnumerator RespawnCoinCorutine(Vector3 position)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(5);
        yield return waitForSeconds;
        GameObject coin = Instantiate(_coinPrefab, position, Quaternion.identity);
    }
}
