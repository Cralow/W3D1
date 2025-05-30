using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float sped;
    public PlayerShooterController pSC;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            pSC.AddScore();

            collision.gameObject.GetComponent<Enemy>().GetDamage();

            AudioSource[] aslist = collision.gameObject.GetComponents<AudioSource>();
            int randomAu = Random.Range(0, aslist.Length);
            aslist[randomAu].Play();


            Destroy(gameObject);

        }
 
    }
    

}
