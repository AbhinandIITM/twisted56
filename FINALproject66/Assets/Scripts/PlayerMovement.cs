using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//needed for using the new input system

public class PlayerMovement : MonoBehaviour
{
    //we create an object so that we can access the mapping we ve done in the input actions
    PlayerControls controls;
    GameObject PlayerC;//change acc to player
public GameObject playercamera;
    public Rigidbody rb;
    int frame = 0;
    float moving = 0;
    
    public float MoveJ=10000f;
    Vector2 move;
    public float zxforce=7f;

    public Transform gun;
    public Rigidbody rbG;
    public Vector3 direction;

    /// Initializing variables, made all of em public
    //public Rigidbody rb;
    bool jumping = false;
    bool jumpkey = false;
    bool turnR = false;
    bool turnL = false;
    bool turnU=false;
    bool turnD=false;
    int jumpcounter = 0;
    float velocityxy = 0;
    float velocityY = 0;
    public float rotationSpeed=5;
    /// Adding the animator asset
    Animator animator;

    /// <summary>
    /// Here the animator works as a series of triggers. so when a variable is set to a particular value the animation plays
    /// general syntax => animator.SetBool("triggername", true); or animator.SetFloat("triggername", value, delayTime, Time.deltatime);
    /// the delayTime variable is set to somthing like .02f or so to increase the duration of the animations if required
    /// 
    /// the trigger moveamount (type float) specifies at what speed the player should run. 0 means idle and 1 means running and anywhere in between will be walking/slow running.
    /// the trigger isjumpingup (type bool) is set to true if the player need to jump ( the isjumpingdown trigger should be set to false prehand)
    /// the trigger is jumpingdown (type bool) is set to true if the player reaches the ground
    /// 
    /// the trigger aimV (type float) specifies how much up the arms should move ( ranges from -1 to 1)
    /// the trigger aimH ( type float) specifies how much to the side the arms should move ( ranges from -1 to 1)
    /// </summary>
    

    public float xrot,yrot,zrot;

    [SerializeField] PlayerInput _playerInput;

    /*void Awake()   //Awake is called even before Start, and is used to initialize the commands
    {
        controls=new PlayerControls();
        controls.Movement.Move.performed+=ctx=>move=ctx.ReadValue<Vector2>();  //here instead of calling another function, we set the value of move according to  movement of function
        controls.Movement.Move.canceled+=ctx=>move=Vector2.zero; //if we stop moving the joystick, then the movement is cancelled/stopped. (spelled canceled in unity)
    }*/
    void Update(){
        playercamera.transform.position = transform.position+ new Vector3(0,10,0);
    }
    //using this function to reset the jumps
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (velocityY < 0 )//changed "scene" to "Building" removed velocity
        {
            animator = GetComponent<Animator>();
            animator.SetBool("isjumpingdown", true);
            
            jumpcounter = 0;
        }
    }

    void OnValidate()
    {
        _playerInput=GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        animator = GetComponent<Animator>();
        
        move =_playerInput.actions["Move"].ReadValue<Vector2>();
        jumpkey=_playerInput.actions["Jump"].IsPressed();
        //jumpkey=controls.Movement.Jump.IsPressed();//returns true if button pressed on controller
        velocityY = rb.velocity.y;
        velocityxy = Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2);
        velocityxy = Mathf.Pow(velocityxy, .5f);
        //Debug.Log(jumpkey);//we get true if pressed
        if(jumpkey == true && jumping == false){
            jumping = true;
            if(jumpcounter < 2){
                animator.SetBool("isjumpingdown", false);
                animator.SetBool("isjumpingup", true);
                frame = 0;
                rb.AddForce(0, MoveJ*Time.deltaTime, 0);
            }
            jumpcounter ++;
        }
        

        if(jumpkey == false){
            jumping = false;
        }
        if(velocityxy < 4)
        {
            Vector3 m=new Vector3(move.x*zxforce,0,move.y*zxforce)*Time.deltaTime;
            //m.Normalize();

            if(velocityY == 0)
            {
                moving = 1.0f;
            }
            else
            {
                moving = 1.0f;
            }

            transform.Translate(m*moving,Space.World);
            //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
            //rb.velocity = direction * m;
            animator.SetFloat("moveamount", m.magnitude*7.1f);
            
            if (m != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(m, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
            }

            //turnR = controls.Movement.RightRot.IsPressed();
            turnR=_playerInput.actions["RightRot"].IsPressed();
            //turnL = controls.Movement.LeftRot.IsPressed();
            turnL=_playerInput.actions["LeftRot"].IsPressed();
            //turnU = controls.Movement.GunUp.IsPressed();
            turnU=_playerInput.actions["GunUp"].IsPressed();
            //turnD = controls.Movement.GunDown.IsPressed();
            turnD=_playerInput.actions["GunDown"].IsPressed();
            if (turnR)
            {
                rb.transform.Rotate(0, 5, 0, Space.Self);
            }
            if (turnL)
            {
                rb.transform.Rotate(0, -5, 0, Space.Self);
            }
            //Vector3 rot = transform.eulerAngles;
            
            //Debug.Log(xrot);
            //xrot = Mathf.Clamp(xrot, -20f, 20f);
            xrot=rbG.transform.eulerAngles.x;
            yrot=rbG.transform.eulerAngles.y;
            zrot=rbG.transform.eulerAngles.z;
            if(xrot<=20 || xrot>=340)
            {
            if (turnD&&(xrot<20 || xrot>340))
            {
                //rbG.transform.Rotate(5, 0, 0, Space.Self);
                //rbG.transform.rotation*=Quaternion.Euler(5f,0f,0f);
                xrot+=5;

            }
            if (turnU&&(xrot<20 || xrot>340))
            {
                //rbG.transform.Rotate(-5, 0, 0, Space.Self);
                //rbG.transform.rotation*=Quaternion.Euler(-5f,0f,0f);
                xrot-=5;

            }
            }
            else if(xrot>20 && xrot<180)
            {
                xrot=19.9f;
            }
            else if(xrot<340 && xrot>180)
            {
                xrot=340.1f;
            }
            rbG.transform.rotation=Quaternion.Euler(xrot,yrot,zrot);
            if (frame < 8)
            {
                frame++;
            }
            else
            {
                animator.SetBool("isjumpingup", false);
            }
            
            //Vector3 rot=new Vector3(rotate.x,0,rotate.y)*rotationconst*Time.deltaTime;
            //transform.rotation = Quaternion.LookRotation(rot);
        }
    }
}
