using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private float _spawnTime;

    private Transform[] _points;
    private Transform _currentPoint;
    private float _runningTime;
    private int _indexPoint;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        _indexPoint = 0;

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        _currentPoint = _points[_indexPoint];
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        if(_runningTime >= _spawnTime)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(_currentPoint.position.x, _currentPoint.position.y, _currentPoint.position.z),
            Quaternion.identity);

            _runningTime = 0;
            if (_indexPoint < _points.Length-1)
                _indexPoint++;
            else
                _indexPoint = 0;
            _currentPoint = _points[_indexPoint];
        }
    }
}
