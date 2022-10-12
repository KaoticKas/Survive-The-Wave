using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]

    public class Wave
    {
        public string waveName;
        public Transform[] enemy;
        public int count;
        public float spawnRate;
        public int enemyDmg = 5;
        public int enemyHealth = 100;
        public float enemySpeed = 1.0f;
        public int pointPerEnemy = 10;

    }
    public Wave[] waves;
    private int waveIndex = 0;


    public Transform[] Spawners;

    public float timeBetweenWave = 5f;
    private float waveCount = 0;

    private float searchCount = 1f;

    public int waveNum = 1;

    private SpawnState state = SpawnState.COUNTING;

    

    void Start()
    {
        waveCount = timeBetweenWave;
    }
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (IsAlive() == false)
            {
                NewRound();
            }
            else
            {
                return;
            }
        }

        if (waveCount<= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[waveIndex]));
            }
        }
        else
        {
            waveCount -= Time.deltaTime;
        }
    }


    void NewRound()
    {
        state = SpawnState.COUNTING;
        waveCount = timeBetweenWave;
          
        if (waveIndex + 1 > waves.Length - 1)
        {
            waveNum++;
            waveIndex = 0;
            waves[waveIndex].count = waves[waveIndex].count + Random.Range(1,5);
            waves[waveIndex].spawnRate = waves[waveIndex].spawnRate + 0.5f;
            waves[waveIndex].enemyDmg = waves[waveIndex].enemyDmg + 2;
            waves[waveIndex].enemySpeed = waves[waveIndex].enemySpeed + 0.1f;
            waves[waveIndex].enemyHealth = waves[waveIndex].enemyHealth + 10;
            waves[waveIndex].pointPerEnemy = waves[waveIndex].pointPerEnemy + Random.Range(1 , 28);
        }
        else
        {

            waveIndex++;
            waveNum++;
        }
    }


    bool IsAlive()
    {
        searchCount -= Time.deltaTime;
        if (searchCount <= 0f)
        {
            searchCount = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("spawing wave");

        state = SpawnState.SPAWNING;
        for (int i =0; i < _wave.count; i++)
        {
            //Enemy enemyComponent = _wave.enemy.;

            //enemyComponent.enemyHealth = waves[waveIndex].enemyHealth;
            //enemyComponent.speed = waves[waveIndex].enemySpeed;
            //enemyComponent.enemyDamage = waves[waveIndex].enemyDmg;
            //enemyComponent.points = waves[waveIndex].pointPerEnemy;
            SpawnEnemy(_wave.enemy);

            
            yield return new WaitForSeconds(1f / _wave.spawnRate);
            
        }
        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform[] _enemy)
    {

        int x;
        x = Random.Range(0, _enemy.Length);

        Transform _sp = Spawners[Random.Range(0, Spawners.Length)];
        Instantiate(_enemy[x], _sp.position, _sp.rotation);

    }
}
