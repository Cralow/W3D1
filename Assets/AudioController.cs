using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource ost;
    void Start()
    {
        ost.Play();
        ost.loop = true;
    }

}
