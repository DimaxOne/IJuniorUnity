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
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds timeWait = new WaitForSeconds(5);

        for (int i = 0; i < _coinSpawnPosition.Length; i++)
        {
            GameObject coin = Instantiate(_coinPrefab, _coinSpawnPosition[i].position, Quaternion.identity);
        }

        yield return null;
    }
}
