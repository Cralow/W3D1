using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] float fireRate;
    public float fireCoolDown;


    [SerializeField] float fireRange;
    private GameObject obj;


    public GameObject bulletPrefab;

    public Text scoreText;
    public int score;


    private PlayerController playerController;
    public Transform buttonCanvas;

    private void Start()
    {
        buttonCanvas.gameObject.SetActive(false);
        playerController = GetComponent<PlayerController>();
    }
    public GameObject FindNearestEnemy()
    {
        GameObject[] listaNemici = GameObject.FindGameObjectsWithTag("Enemy");

     

        if(listaNemici.Length > 0)
        {
            float distanzaAttuale;
            float distanza2 = 1000;


            foreach (GameObject go in listaNemici)
            {
                
                Vector3 diff = gameObject.transform.position - go.transform.position;
                distanzaAttuale = diff.magnitude;

               if(distanzaAttuale < distanza2 && distanzaAttuale < fireRange)
                {
                    distanza2 = distanzaAttuale;

                      obj = go;    
                }
               

            

               
            }
        }

        return obj;


    }
    // Update is called once per frame
    void Update()
    {
        fireCoolDown -= Time.deltaTime;

        if (fireCoolDown <= 0f)
        {
            Shoot();
            
            fireCoolDown = fireRate;

            


        }


      
    }

    public void UpGradePlayer()
    {
        if(score == 30)
        {
            buttonCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;

            score = 0;

        }
    }
    public void UpAtkSpeedOnClick()
    {
        fireRate = fireRate/2;
        Resume();
    }
    public void UpSpeedOnClick()
    {
        playerController._speed += 0.5f;
        Resume();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        buttonCanvas.gameObject.SetActive(false);
    }


    public void AddScore()
    {
        score ++;
        scoreText.text = score.ToString();
        UpGradePlayer();
    }
    public void Shoot()
    {
        GameObject fne = FindNearestEnemy();
        if (fne != null)
        {
            Vector2 fireDirection = fne.transform.position - transform.position;

            var a = Instantiate(bulletPrefab,transform);

           float force = a.GetComponent<Bullet>().sped;

            a.GetComponent<Rigidbody2D>().AddForce(fireDirection * force, ForceMode2D.Impulse);
             a.GetComponent<Bullet>().pSC = gameObject.GetComponent<PlayerShooterController>();
            //new Vector2(FindNearestEnemy().transform.position.x ,transform.position.y)

            //UI

        }

       // print(FindNearestEnemy().name);

    }

    }


