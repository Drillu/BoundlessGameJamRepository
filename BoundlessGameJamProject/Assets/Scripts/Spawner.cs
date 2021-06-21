﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    float randY,randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.5f;

    float i;
    int j;

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(12f, 18f);
            randY = Random.Range(-5f, 5f);
            whereToSpawn = new Vector2(randX, randY);
            i = Random.Range(0, 100);
            if (i > 30) j = 0;
            else if (i <= 30) j = 1;

            Instantiate(enemy[j], whereToSpawn, Quaternion.identity);
        }
    }
}
