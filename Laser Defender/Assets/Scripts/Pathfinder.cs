using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfiguraitonSO waveConfig;
    List<Transform> waypoints;

    int intWaypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[intWaypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (intWaypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[intWaypointIndex].position;
            float fltDelta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, fltDelta);

            if (transform.position == targetPosition)
            {
                intWaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
