using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health=20;
    public float damage=5;
    
    void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("hit");
   
            health -= damage;
            Destroy(other.gameObject);
        }
        
    }
}
