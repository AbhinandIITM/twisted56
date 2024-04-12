using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
   
    //public float lifetime=2;

    void Update()
    {
        /*lifetime-=Time.deltaTime;
        if(lifetime<0)
        {
            Destroy(gameObject);
        }*/
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

    }


}
