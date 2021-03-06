﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float waveTimer = 5f;
    private float countDown = 2f;

    public Text waveCountDownTimerText;
    private int waveNumber = 0;

    void Update(){
        if(countDown <= 0f){
            StartCoroutine(spawnWave());
            countDown = waveTimer;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownTimerText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator spawnWave(){
        Debug.Log("Wave incoming " + waveNumber);
        waveNumber++;
        for(int i=0; i<waveNumber; i++){
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
