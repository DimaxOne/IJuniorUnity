using UnityEngine;

public class RobotSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _robotPrefab;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _spawnPositions;

    private void Start()
    {
        _spawnPositions = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawnPositions[i] = _spawnPoints.GetChild(i);
            GameObject robot = Instantiate(_robotPrefab, _spawnPositions[i].position, Quaternion.identity);
        }
    }

}
