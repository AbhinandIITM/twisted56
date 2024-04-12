using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GunRot : MonoBehaviour
{
    public Transform gun;
    
    
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        float xrot=rot.x;
        Debug.Log(xrot);
    }
}
