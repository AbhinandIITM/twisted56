using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityreset : MonoBehaviour
{
    public float lastGravity;
    // Start is called before the first frame update
    void Start()
    {
        lastGravity = Physics.gravity.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Physics.gravity.y - lastGravity) > 1f){
            Debug.Log("gravity reset after 5seconds");
Invoke("resetgravity",5f);
        }
    }

    void resetgravity(){
Physics.gravity = new Vector3(0f, -10f, 0f);
Debug.Log("gravity reset");
    }
}
