using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float _speed;


    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
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

    }



}
