﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    private float countdown = 2f;
    private int waveIndex = 0;

    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    public Transform spwanPoint;
    public Text waveCountDownText;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spwanPoint.position, spwanPoint.rotation);
    }
}
