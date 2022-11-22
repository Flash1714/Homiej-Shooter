using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float minTimeBtwSpawn;
    public float timeDecrement;
    
    //For spawning system
    System.Random rnd = new System.Random();
    int[] spawns = {0,1,2,3,4,5,6,7,8,9,10,11}; //Total number of spawn points 
    private List<int> randSpawn;
    
       

    // Update is called once per frame
    void Update()
    {
        int numberOfSpawns = Random.Range(4, 7);

        if (timeBtwSpawn <= 0)
        {
            randSpawn = spawns.OrderBy(x => rnd.Next()).Take(numberOfSpawns).ToList();
            
            for (int i = 0; i < numberOfSpawns; i++)
            {
                int randEnemy = Random.Range(0, enemies.Length);
                Instantiate(enemies[randEnemy], spawnPoints[randSpawn[i]].position, Quaternion.identity);
            }
            
            timeBtwSpawn = startTimeBtwSpawn;
            if(startTimeBtwSpawn > minTimeBtwSpawn)
            {
                startTimeBtwSpawn -= timeDecrement;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;

        }
    }
}
