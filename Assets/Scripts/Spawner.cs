using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject[] spawnerlist;
    private float spawnCoolDown;
   [SerializeField]  float spawnRate = 2;
    int enemyCounter;
    public GameObject enemyPrefab;

    float enemyVel;


    void Start()
    {
       spawnerlist= GameObject.FindGameObjectsWithTag("spawn");
         enemyVel = 0;
    }

    // Update is called once per frame
    void Update()
    {

        CheckEnemy(); 
    }
   public void CheckEnemy()
    {
        
        spawnCoolDown -= Time.deltaTime;

        if (spawnCoolDown <= 0f)
        {
            SpawnRandomPosition(enemyVel);
            spawnCoolDown = spawnRate;

            enemyCounter++;
           if (enemyCounter % 20 ==0&&enemyCounter<80)
            {
                spawnRate /= 2;
                Debug.Log("Aumento i nemici");



                enemyVel += 0.3f;
            }
           

        }
    }


    public void SpawnRandomPosition(float v)
    {
        var a =Instantiate(enemyPrefab);
        a.transform.position = spawnerlist[Random.Range(0, spawnerlist.Length)].transform.position;
        a.GetComponent<Enemy>().speed += v;


    }
}
