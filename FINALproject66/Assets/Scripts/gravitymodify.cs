using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEditor.Animations;

public class gravitymodify : MonoBehaviour
{

    
    public float gravity;
    
    public bool isinvertgravity,islessgravity,ismoregravity;

    private Vector3 default_gravity;
    public List<Variables> collectibles = new List<Variables>{};
    
    public float health=20;
    public float damage=5;
   
    // Start is called before the first frame update
void Start()
    {
    
        
        Physics.gravity =new Vector3(0,-10.0F,0);
        isinvertgravity = false;
        islessgravity=false;
        ismoregravity=false;
    
    }

 


private void Update(){
    
  if(health<=0)
        {
            Destroy(gameObject);
        }
     /*if(Input.GetKey(KeyCode.Space)){
    
   rb.position = new Vector3(rb.position.x,1.5f,rb.position.z);
   }
   else{
    rb.position = new Vector3(rb.position.x,0f,rb.position.z);
   }*/
    gravity = Physics.gravity.y;
// if(isinvertgravity == true){
//     if(Input.GetKey(KeyCode.G)){
        
//     Physics.gravity =new Vector3(0,10.0F,0);
//     }
// }
// if(ismoregravity == true){
//     if(Input.GetKey(KeyCode.G)){
        
//     Physics.gravity =new Vector3(0,-20.0F,0);
//     }
// }
// if(islessgravity == true){
//     if(Input.GetKey(KeyCode.G)){
       
//     Physics.gravity =new Vector3(0,-5.0F,0);
//     }
// }
/*if(!(isinvertgravity)){
    Physics.gravity = new Vector3(0,-10.0F,0);
}*/

}
    void OnTriggerEnter(Collider other) 
   {
Debug.Log($"invert:{isinvertgravity} less: {islessgravity} more: {ismoregravity}");
    
    //drag and drop invertgravity gameobject in prefabs folder. 
    //Click on tag in invertgravity prefab, create invertgravity tag and apply it to the prefab.
    if(other.CompareTag("Bullet")){
        Debug.Log("bullet detected");
        Transform collectible_brick = gameObject.transform.GetChild(3);
        Debug.Log($"{collectible_brick.tag}");
    if (collectible_brick.CompareTag("invertgravity")) 
       {
        
        // isinvertgravity = true;
        // ismoregravity = false;
        // islessgravity = false;
        Physics.gravity =new Vector3(0,2.0F,0);
        collectible_brick.tag = "Untagged";
        //Invoke("removeinvertgravity",5f);
        
        // Deactivate the collided object (making it disappear).     
      // other.gameObject.SetActive(false);
       }
       if(collectible_brick.CompareTag("moregravity")){
        // ismoregravity = true;
        //  isinvertgravity = false;
        // islessgravity =false;
        Physics.gravity =new Vector3(0,-20.0F,0);
        collectible_brick.tag = "Untagged";
       // Invoke("removemoregravity",5f);
        
        // Deactivate the collided object (making it disappear).     
       //other.gameObject.SetActive(false);
       }
       if(collectible_brick.CompareTag("lessgravity")){
        // islessgravity = true;
        //  isinvertgravity =false;
        //  ismoregravity = false;
        Physics.gravity =new Vector3(0,-5.0F,0);
      collectible_brick.tag = "Untagged";
       //Invoke("removelessgravity",5f);
      
        // Deactivate the collided object (making it disappear).     
       //other.gameObject.SetActive(false);
       }
       health-=damage;
       //Destroy(other.gameObject);
   }
       
   }
    void removeinvertgravity(){
        Debug.Log("removed invertg");
        //isinvertgravity = false;
        Physics.gravity = new Vector3(0,-10.0F,0);
    }
        void removemoregravity(){
        
       // isinvertgravity = false;
        Physics.gravity = new Vector3(0,-10.0F,0);
        Debug.Log("removed moreg");
    }
    void removelessgravity(){
        
       // isinvertgravity = false;
        Physics.gravity = new Vector3(0,-10.0F,0);
        Debug.Log("removed lessg");
    }   
    
}
    




        
    
   

