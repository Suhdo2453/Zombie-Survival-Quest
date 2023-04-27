using System;
using System.Collections;
using System.Collections.Generic;
using Ultilites;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Serializable]
public class TypeEnemy
{
    public GameObject Enemy;

    public int totalEnemy
    {
        get => TotalEnemy;
        private set => TotalEnemy = value;
    }

    [SerializeField] private int TotalEnemy;

    public void DecreaseTotalEnemy()
    {
        totalEnemy--;
    }
}

[Serializable]
public class Wave
{
    public string WaveName;
    public TypeEnemy[] typeEnemies;
    public float spawnInterval;
    public int timeToChangeWave;

    public bool canSpawn = true;

    public void CheckCanSpawn()
    {
        foreach (TypeEnemy type in typeEnemies)
        {
            if (type.totalEnemy > 0)
            {
                canSpawn = true;
                return;
            }
        }

        canSpawn = false;
    }
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
        if (currentWave.canSpawn && nextSpawnTime < Time.time)
        {
            TypeEnemy typeEnemy = currentWave.typeEnemies[Random.Range(0, currentWave.typeEnemies.Length)];
            GameObject randomEnemy = typeEnemy.Enemy;
            if (typeEnemy.totalEnemy > 0)
            {
                GameObject obj = ObjectPooler.Instance.GetPooledObject(randomEnemy);
                obj.SetActive(true);
                obj.transform.position = SpawnPos();
                nextSpawnTime = Time.time + currentWave.spawnInterval;
                typeEnemy.DecreaseTotalEnemy();
                currentWave.CheckCanSpawn();
            }
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
        if (Mathf.FloorToInt(GameManager.Instance.currentTime).Equals(currentWave.timeToChangeWave) && !currentWave.canSpawn)
        {
            currentWaveIndex++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerPos.position, radius);
    }
}