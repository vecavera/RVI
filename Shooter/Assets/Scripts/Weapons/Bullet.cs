using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public int damage;

    public void Setup(int damage)
    {
        this.damage = damage;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    
    

    private void OnCollisionEnter(Collision other) 
    {
        if(other != null)
        {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
             Destroy(gameObject);
             Enemy e = other.gameObject.GetComponent<Enemy>();
             e.TakeDamage(damage);
            }
        }

}
