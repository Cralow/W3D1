using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float _speed;


    [SerializeField] Transform[] playerStates;




    public enum PlayerStates 
    {
        Idle,
        Move,
        Sparo,
    }
    void Start()
    {
         rb = gameObject.GetComponent<Rigidbody2D>();
        StateUpdate(PlayerStates.Idle);  



    }


    public void StateUpdate(PlayerStates currentState)
    {
        for (int i = 0; i < playerStates.Length; i++)
        {
           
            
            playerStates[i].gameObject.SetActive(i == (int)currentState);

            //playerStates[0].gameObject.SetActive(currentState == PlayerStates.Idle);
            //playerStates[1].gameObject.SetActive(currentState == PlayerStates.Move);
            //playerStates[2].gameObject.SetActive(currentState == PlayerStates.Sparo);
        }

        //if (currentState == PlayerStates.Idle)
        //{
        //    playerStates[0].gameObject.SetActive(true);


        //}
        //if (currentState == PlayerStates.Move)
        //{
        //    playerStates[1].gameObject.SetActive(true);

        //}
        //if (currentState == PlayerStates.Sparo)
        //{

        //    playerStates[2].gameObject.SetActive(true);
        //}
    }
    // Update is called once per frame
    void Update()
    {
        Movement();



    }

    public void Movement()
    {

        var a = Input.GetAxis("Horizontal");
        var b = Input.GetAxis("Vertical");
        Vector2 endPosition = new Vector2(a, b).normalized;
       rb.velocity = endPosition * (_speed + Time.deltaTime);


        if (a > 0)
        {
            print("destra");
            StateUpdate(PlayerStates.Move);
            transform.GetComponentInChildren<SpriteRenderer>().flipX = false;

            //flippa il component
        }
        else if (a < 0)
        {
            print("sinistra");
            StateUpdate(PlayerStates.Move);
            transform.GetComponentInChildren<SpriteRenderer>().flipX = true;

            //flippa
        }



    }



}
