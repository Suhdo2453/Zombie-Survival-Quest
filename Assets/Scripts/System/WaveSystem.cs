using System;
using System.Collections;
using System.Collections.Generic;
using Ultilites;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Serializable]
public class Wave
{
    public string waveName;
    public GameObject[] prefab;
    public float spawnInterval;
    public int timeToChangeWave;
}

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float radius;

    private Wave currentWave;
    private int currentWaveIndex;
    private float nextSpawnTime;

    private void Update()
    {
        currentWave = waves[currentWaveIndex];
        SpawnWave();
        NextWave();
    }

    private void SpawnWave()
    {
        if (nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.prefab[Random.Range(0, currentWave.prefab.Length)];
            GameObject obj = ObjectPooler.Instance.GetPooledObject(randomEnemy);
            obj.SetActive(true);
            obj.transform.position = SpawnPos();
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
    }

    private Vector2 SpawnPos()
    {
        float angle = Random.Range(0, 360); // Chọn ngẫu nhiên một góc trên đường tròn
        float x = radius * Mathf.Sin(angle * Mathf.Deg2Rad); // Tính toán vị trí x của enemy
        float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad); // Tính toán vị trí y của enemy

        return new Vector2(playerPos.position.x + x, playerPos.position.y + y); // Tính toán vị trí chính xác của enemy
    }

    private void NextWave()
    {
        if (Mathf.FloorToInt(GameManager.Instance.currentTime).Equals(currentWave.timeToChangeWave))
        {
            currentWaveIndex++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerPos.position, radius);
    }
}