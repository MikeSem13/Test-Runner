using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    public GameObject RoadPrefab;
    public Transform PlayerTransform;

    public float SpawnTarget = 60;
    public float TileLenght = 150;

    public int NumberOfRoads = 3;

    private List<GameObject> ActiveRoads = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < NumberOfRoads; i++)
        {
            SpawnRoad();
        }
    }

    private void Update()
    {
        if (PlayerTransform.position.z + 50 > SpawnTarget - (TileLenght))
        {
            SpawnRoad();
            DeleteRoad();
        }
    }

    public void SpawnRoad()
    {
        GameObject Road = Instantiate(RoadPrefab, transform.forward * SpawnTarget, transform.rotation);
        ActiveRoads.Add(Road);
        SpawnTarget += TileLenght;
    }

    public void DeleteRoad()
    {
        Destroy(ActiveRoads[0]);
        ActiveRoads.RemoveAt(0);
    }
}
