using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 关卡生成器
/// </summary>
public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms;
    public GameObject winPointPrefab;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.8f;
    private float lastx;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            float tmpx = Random.Range(-levelWidth, levelWidth);
            while (Math.Abs(tmpx - lastx) > 4f)
            {
                tmpx = Random.Range(-levelWidth, levelWidth);
            }

            lastx = tmpx;
            spawnPosition.x = tmpx;

            if (i == numberOfPlatforms - 1)
            {
                //生成win point
                Instantiate(winPointPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}