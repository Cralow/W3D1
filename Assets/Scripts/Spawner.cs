using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Spawner : MonoBehaviour
{
    GameObject[] spawnerlist;
    private float spawnCoolDown;
   [SerializeField]  float spawnRate = 2;
    int enemyCounter;
    public GameObject enemyPrefab;

    float enemyVel;


    public Sprite[] enemySprites;
    public int enemyTier;


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
            SpawnRandomPosition(enemyVel, enemyTier);
            spawnCoolDown = spawnRate;

            enemyCounter++;
           if (enemyCounter % 20 ==0&&enemyCounter<80)
            {
                spawnRate /= 2;
                Debug.Log("Aumento i nemici");

                if (enemyTier<4)
                {
                    enemyTier++;
                }
                


                enemyVel += 0.3f;
            }
           

        }
    }


    public void SpawnRandomPosition(float v,int tier)
    {
        var a =Instantiate(enemyPrefab);
        a.transform.position = spawnerlist[Random.Range(0, spawnerlist.Length)].transform.position;
       a.GetComponent<Enemy>().speed += v;
        a.GetComponent<Enemy>().res = 1 + tier;
        a.GetComponent<SpriteRenderer>().sprite = enemySprites[tier];



        //if (a.GetComponent<Enemy>().res == 2)
        //{
        //    a.GetComponent<SpriteRenderer>().sprite = enemySprites[0];
        //}
        //else if (a.GetComponent<Enemy>().res == 3)
        //{
        //    a.GetComponent<SpriteRenderer>().sprite = enemySprites[1];
        //}
        //else if (a.GetComponent<Enemy>().res == 4)
        //{
        //    a.GetComponent<SpriteRenderer>().sprite = enemySprites[2];
        //}



    }
}
