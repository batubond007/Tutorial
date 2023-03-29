using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bloodParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Zombie"))
        {
            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            zombie.Kill();
            Destroy(gameObject);
        }
    }
}
