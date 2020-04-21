using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Allows use of UI commands

public class Spawner : MonoBehaviour
{
    public Transform mimic;

    public Transform Enemy1;
    public Transform Enemy2;
    public Transform Enemy3;
    public Transform Enemy4;

    public Transform DaMiniBoss;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f; // Timer before enemies start spawinng

    public Text waveCountdownText; //UI display of wave number
    public Text levelCleared;

    private int waveIndex = 1;//Number of the actual wave

    private int enemyCounter = 0; //determines how many enemies per wave spawn  

    public static int enemiesLeft;//keeps track of the number of living enemies

    Vector2 newPosition;

    private bool TextTracker = true; // ASDAFASDFASDF = Nomas para evitar que todos los spawners intenten accesar el wave countdown text en lo que lo movemos a otro lado
    void Start()
    {
        // ASDASDFSDASDFASDF
        if (waveCountdownText && levelCleared == null)
        {
            TextTracker = false;
        }
    }


    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;

            if (TextTracker == true) // ASDFASFASDFASDFASDF
            {
                // waveCountdownText.gameObject.SetActive(false);
            }


        }
        if (waveIndex == 6 && enemiesLeft == 0)
        {
            if (TextTracker == true) // ASDASDASDASDADSASDF
            {
                levelCleared.text = "LEVEL CLEARED";
                Debug.Log("Level cleared" + enemiesLeft);
            }

        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //mathf.round cuts the decimals remaining from the countdown variable
        //so that the ToString function can properly convert from numerical to 
        //string value
        if (TextTracker == true) // ASDASDASDASDADSASDF
        {
            // waveCountdownText.text = string.Format("{0:00.00}", countdown);
        }

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
                        spawnEnemy1();
                        yield return new WaitForSeconds(1f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;

                case 2:
                    while (enemyCounter < 3)
                    {
                        spawnEnemy2();
                        yield return new WaitForSeconds(1f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;
                case 3:
                    while (enemyCounter < 3)
                    {
                        spawnEnemy3();
                        yield return new WaitForSeconds(1f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;

                case 4:
                    while (enemyCounter < 1)
                    {
                        spawnEnemy4();
                        yield return new WaitForSeconds(1f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;
                case 5:
                    while (enemyCounter < 1)
                    {
                        spawnDaMiniBoss();
                        yield return new WaitForSeconds(1f);
                        enemyCounter++;
                    }
                    enemyCounter = 0;
                    waveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
                    break;

            }
        }


    }
    void spawnEnemy1()
    {
        Vector3 position1 = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));

        Instantiate(Enemy1, spawnPoint.position + position1, spawnPoint.rotation);//spawn on top of spawner
        enemiesLeft++;
    }

    void spawnEnemy2()
    {
        Vector3 position1 = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        Instantiate(Enemy2, spawnPoint.position + position1, spawnPoint.rotation);//spawn on top of spawner
        enemiesLeft++;
    }

    void spawnEnemy3()
    {
        Vector3 position1 = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        Instantiate(Enemy3, spawnPoint.position + position1, spawnPoint.rotation);//spawn on top of spawner
        enemiesLeft++;
    }

    void spawnEnemy4()
    {
        Vector3 position1 = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        Instantiate(Enemy4, spawnPoint.position + position1, spawnPoint.rotation);//spawn on top of spawner
        enemiesLeft++;
    }

    void spawnDaMiniBoss()
    {
        Vector3 position1 = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        Instantiate(DaMiniBoss, spawnPoint.position + position1, spawnPoint.rotation);
        enemiesLeft++;
    }


}