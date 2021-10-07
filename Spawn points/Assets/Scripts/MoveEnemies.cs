using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        gameObject.transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
