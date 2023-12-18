using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfiguraitonSO> waveConfigs;
    [SerializeField] float fltTimeBetweenWaves = 0f;
    WaveConfiguraitonSO currentWave;


    [SerializeField]bool boolIsLooping = true;
    public WaveConfiguraitonSO GetCurrentWave()
    {
        return currentWave;
    }
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfiguraitonSO wave in waveConfigs)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }
        } while (boolIsLooping == true);


        yield return new WaitForSeconds(fltTimeBetweenWaves);
    }
    
}
