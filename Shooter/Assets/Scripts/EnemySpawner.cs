using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public List<Transform> spawnPoints = new List<Transform>();
    public int numberOfEnemies;
    private int enemyCount;
    public int spawnTime;

    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine(spawnTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnCoroutine(int time){

        while(true){
        System.Random randIndex = new System.Random();
        int index = randIndex.Next(0,spawnPoints.Count);
        Vector3 spawnPos = spawnPoints[index].position;
        GameObject instantietedEnemy = Instantiate(enemyPrefab,spawnPos,Quaternion.identity);
        spawnedEnemies.Add(instantietedEnemy);
        
        enemyCount++;
        if(enemyCount >= numberOfEnemies){
            yield break;
        }
        yield return new WaitForSecondsRealtime(time);
        }


    }
}
