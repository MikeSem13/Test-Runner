using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private RoadModel Road;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private float DistanceBetweenCoins;

    private int LineToSpawn;
    
    public float SpawnPoint;

    private void Update()
    {
        DestroyMissCoins();
    }

    public void DestroyMissCoins()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).transform.position.z < PlayerPosition.position.z - 25)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
    
    public void SpawnCoin()
    {
        LineToSpawn = Random.Range(-1, 2);
        int countOfCoins = Random.Range(4, 9);
        for (int i = 0; i < countOfCoins; i++)
        {
            GameObject SpawnCoin = Instantiate(CoinPrefab,new Vector3(Road.LineDistance * LineToSpawn,CoinPrefab.transform.position.y,SpawnPoint + DistanceBetweenCoins * i),CoinPrefab.transform.rotation);
            SpawnCoin.transform.SetParent(transform);
        } 
        SpawnPoint += Random.Range(40,71);
    }
}
