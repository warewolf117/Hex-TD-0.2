using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class WaveSpawnerTopRight_Main : MonoBehaviour
{

   // public static int EnemiesAlive = 0;

    public static int EnemyCount = 0;

    public Wave[] waves;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    private int spawnSpacer = 1;

    
    
    public Transform WaveIndicatorPosition;
    public GameObject waveStarter;
    public GameObject waveIndicator;
    private bool waveIndicatorPlaced = false;
    private bool noEnemiesComing = false;
    public static int startFirstWave = 0;
    

    public float timeBetweenWaves = 3f;
    public static float countdown = 4f;

    
    public Text waveCountdownText;

    public Text levelCleared;

    private int waveIndex = 0;


    private void Start()
    {
        Wave wave = waves[waveIndex];
        waveIndex++;
        if (wave.count == 0)
        {
            noEnemiesComing = true;

        }
        else
        {
            noEnemiesComing = false;
        }

        if (noEnemiesComing == false)
        {
            waveStarter.SetActive(true);
        Instantiate(waveStarter, WaveIndicatorPosition.position, Quaternion.Euler(90f, 30f, 0f));

        }
        waveIndex--;

    }


    public void WaveStart ()
    {
        startFirstWave++;
        Debug.Log("Wave Started");
        
    }

    void Update()
    {
      
       if (startFirstWave <= 0)
        {
            return;
        }
        

        if (Wave.EnemiesAlive > 0 && EnemyCount > 0)
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

            GameObject[] objects = GameObject.FindGameObjectsWithTag("WaveIndicator");

            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }
            waveIndicatorPlaced = false;
            return;
        }

        if (Wave.EnemiesAlive == 0 && waveIndex != waves.Length)
        {
            Wave wave = waves[waveIndex];
            waveIndex++;
            if (wave.count == 0)
            {
                noEnemiesComing = true;
            }
            else
            {
                noEnemiesComing = false;
            }
            

            if (waveIndicatorPlaced == false && waveIndex > 1 && noEnemiesComing == false)
            {            
                waveIndicator.SetActive(true);
                Instantiate(waveIndicator, WaveIndicatorPosition.position, Quaternion.Euler(90f, 30f, 0f));
                waveIndicatorPlaced = true;
                
            }
            waveIndex--;

            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

            waveCountdownText.text = string.Format("{0:00.00}", countdown);

        }
        
       
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemyCount = wave.count;
       // EnemiesAlive = 0;

        //Debug.Log("enemy count:" + EnemyCount);

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
       
       

    }

    void SpawnEnemy(GameObject enemy)
    {
       // Debug.Log("spawn position: " + spawnSpacer);
        switch (spawnSpacer)
        {
            case 1:
                Vector3 position1 = new Vector3(1, 0, 1);

                Instantiate(enemy, spawnPoint1.position + position1, spawnPoint1.rotation);
                Wave.EnemiesAlive++;
                spawnSpacer++;
                Debug.Log("enemies Alive:" + Wave.EnemiesAlive);
                break;

            case 2:
                Vector3 position2 = new Vector3(1, 0, 1);

                Instantiate(enemy, spawnPoint2.position + position2, spawnPoint2.rotation);
                Wave.EnemiesAlive++;
                spawnSpacer++;
                Debug.Log("enemies Alive:" + Wave.EnemiesAlive);
                break;
            case 3:
                Vector3 position3 = new Vector3(1, 0, 1);

                Instantiate(enemy, spawnPoint3.position + position3, spawnPoint3.rotation);
                Wave.EnemiesAlive++;
                spawnSpacer++;
                Debug.Log("enemies Alive:" + Wave.EnemiesAlive);
                break;

            case 4:
                Vector3 position4 = new Vector3(1, 0, 1);

                Instantiate(enemy, spawnPoint4.position + position4, spawnPoint4.rotation);
                Wave.EnemiesAlive++;
                spawnSpacer++;
                Debug.Log("enemies Alive:" + Wave.EnemiesAlive);
                break;
            case 5:
                Vector3 position5 = new Vector3(1, 0, 1);

                Instantiate(enemy, spawnPoint5.position + position5, spawnPoint5.rotation);
                Wave.EnemiesAlive++;
                spawnSpacer = 1;
                Debug.Log("enemies Alive:" + Wave.EnemiesAlive);

                break;


        }
    }

}