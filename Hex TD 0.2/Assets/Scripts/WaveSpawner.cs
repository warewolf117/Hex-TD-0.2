using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public static int EnemyCount = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 4f;

    
    public Text waveCountdownText;

    public Text levelCleared;

    private int waveIndex = 0;

    void Update()
    {
        if (EnemiesAlive > 0 && EnemyCount > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            waveCountdownText.enabled = false;
            levelCleared.text = "LEVEL CLEARED";
            Debug.Log("Level cleared");

            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

      
            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

            Debug.Log("Time is: " + countdown);

            waveCountdownText.text = string.Format("{0:00.00}", countdown);
        
       
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemyCount = wave.count;
        EnemiesAlive = 0;

        //Debug.Log("enemy count:" + EnemyCount);

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveIndex++;
        Debug.Log("Wave =" + waveIndex);
    }

    void SpawnEnemy(GameObject enemy)
    {

        Vector3 position1 = new Vector3(Random.Range(-3f, 3f), 1, Random.Range(-3f, 3f));

        Instantiate(enemy, spawnPoint.position + position1, spawnPoint.rotation);
        EnemiesAlive ++;
        //Debug.Log("enemies Alive:" + EnemiesAlive);
    }

}