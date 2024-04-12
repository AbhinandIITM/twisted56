using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DineshMovement : MonoBehaviour
{
    /// Initializing variables
    public Rigidbody rb;
    bool jumping = false;
    bool jumpkey = false;
    bool turnR = false;
    bool turnL = false;
    bool moveF = false;
    bool moveB = false;
    int jumpcounter = 0;
    float velocityxy = 0;
    float velocityY = 0;

    /// Checking for collisions and reseting doublejump counter
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Building" && velocityY < 0)//changed "scene" to "Building"
        {
            jumpcounter = 0;
        }
    }

    void FixedUpdate()
    {

        ///Getting Inputs
        moveF = Input.GetKey("s");
        moveB = Input.GetKey("w");
        jumpkey = Input.GetKey("j");
        turnR = Input.GetKey("d");
        turnL = Input.GetKey("a");
        
        ///Updating velocities
        velocityY = rb.velocity.y;
        velocityxy = Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2);
        velocityxy = Mathf.Pow(velocityxy, .5f);

        ///Making movements in plane only if planar velocity is less than threoshold value
        if(velocityxy < 4)
        {
            if(moveF){
                rb.AddForce(800*Time.deltaTime, 0, 0);
            }
            if(moveB){
                rb.AddForce(-800*Time.deltaTime, 0, 0);
            }
            if(turnR){
                rb.AddForce(0, 0, 800*Time.deltaTime);
            }
            if(turnL){
                rb.AddForce(0, 0, -800*Time.deltaTime);
            }
        }

        ///Double jump
        if(jumpkey == true && jumping == false){
            jumping = true;
            if(jumpcounter < 2){
                rb.AddForce(0, 10000*Time.deltaTime, 0);
            }
            jumpcounter ++;
        }

        if(jumpkey == false){
            jumping = false;
        }
    }
}
