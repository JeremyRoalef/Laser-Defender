using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]

public class WaveConfiguraitonSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float fltMoveSpeed = 5f;
    [SerializeField] float fltTimeBetweenEnemySpawns = 1f;
    [SerializeField] float fltSpwanTimeVariance = 0f;
    [SerializeField] float fltMinSpawnTime = 0.3f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return fltMoveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int intPrefabIndex)
    {
        return enemyPrefabs[intPrefabIndex];
    }

    public float GetRandomSpawnTime()
    {
        float fltSpawnTime = Random.Range(fltTimeBetweenEnemySpawns - fltSpwanTimeVariance, fltTimeBetweenEnemySpawns + fltSpwanTimeVariance);

        return Mathf.Clamp(fltSpawnTime, fltMinSpawnTime, float.MaxValue);
    }
}
