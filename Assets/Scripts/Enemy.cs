using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    PlayerController playerController;


    public int res;
    bool isDead;


    void Awake()
    {
        res = 2;
        playerController = GameObject.FindAnyObjectByType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {

            EnemyMovement();
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
           


    }

    void EnemyMovement()
    {
        if (playerController != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerController.transform.position, speed * Time.deltaTime);
        }
   
    }
    public void GetDamage()
    {

        res--;
        
        if (res <= 0)
        {

          Destroy(gameObject,gameObject.GetComponent<AudioSource>().clip.length);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
      
    }
}
