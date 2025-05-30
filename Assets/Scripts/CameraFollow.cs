using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform maincamera;
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //maincamera.transform.parent = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        maincamera.transform.position = new Vector3(transform.position.x,transform.position.y, -10);
    }
}
