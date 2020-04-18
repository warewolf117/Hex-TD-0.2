using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Allows use of UI commands

public class Spawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f; // Timer before enemies start spawinng

    public Text waveCountdownText; //UI display of wave number
    public Text getReadyText;
    public Text levelCleared;

    private int waveIndex = 1;//Number of the actual wave

    private int enemyCounter = 0;

    private GameObject[] enemiesLeft;
    private int count = 1;

    void Start()
    {

    }


    void Update()
    {    

        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        count = enemiesLeft.Length;

        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
            waveCountdownText.gameObject.SetActive(false);
            getReadyText.gameObject.SetActive(false);
                    }
        if (waveIndex == 6 && count == 0)
        {
            levelCleared.text = "LEVEL CLEARED";
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //mathf.round cuts the decimals remaining from the countdown variable
        //so that the ToString function can properly convert from numerical to 
        //string value
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator spawnWave()
    {
        // wave index determines how many waves per level there are
        if (waveIndex <= 5)
        {
            // for each wave theres an specific, modifiable ammount of enemies to spawn
            switch (waveIndex)
            {
                case 1:
                    while (enemyCounter < 2)
                    {
                        spawnEnemy();
                        yield return new WaitForSeconds(0.5f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;

                case 2:
                    while (enemyCounter < 3)
                    {
                        spawnEnemy();
                        yield return new WaitForSeconds(0.5f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;
                case 3:
                    while (enemyCounter < 3)
                    {
                        spawnEnemy();
                        yield return new WaitForSeconds(0.5f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;

                case 4:
                    while (enemyCounter < 4)
                    {
                        spawnEnemy();
                        yield return new WaitForSeconds(0.5f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;
                case 5:
                    while (enemyCounter < 4)
                    {
                        spawnEnemy();
                        yield return new WaitForSeconds(0.5f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;

            }
        }
        

    }
    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//spawn on top of spawner
    }
}