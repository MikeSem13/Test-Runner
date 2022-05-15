using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoadSpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnCoins _spawnCoins;
    
    [SerializeField] private GameObject _roadPrefab;
    [SerializeField] private Transform _playerTransform;
    
    [SerializeField] private float _spawnTarget = 60;
    [SerializeField] private float _tileLenght = 150;

    [SerializeField] private int _numberOfRoads;

    private List<GameObject> ActiveRoads = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _numberOfRoads; i++)
        {
            SpawnRoad();
        }
    }

    private void Update()
    {
        if (_playerTransform.position.z > _spawnTarget - (_tileLenght * 3.5f))
        {
            SpawnRoad();
            DeleteRoad();
        }
        if (_spawnCoins.SpawnPoint < _spawnTarget) _spawnCoins.SpawnCoin();
    }

    public void SpawnRoad()
    {
        GameObject Road = Instantiate(_roadPrefab, transform.forward * _spawnTarget, transform.rotation);
        Road.transform.SetParent(transform);
        ActiveRoads.Add(Road);
        _spawnTarget += _tileLenght;
    }

    public void DeleteRoad()
    {
        Destroy(ActiveRoads[0]);
        ActiveRoads.RemoveAt(0);
    }
}
