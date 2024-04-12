using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    GameObject PlayerC;
    [Header("Bullet Variables")]
    public float bulletspeed,firerate,bulletdmg;
    public bool isAuto;

    [Header("Initial setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    PlayerControls controls;
    private float timer;
    private bool shoot=false;
    private bool shoot1=false;

    [SerializeField] PlayerInput _playerInput;

    void OnValidate()
    {
        _playerInput=GetComponent<PlayerInput>();
    }

    void Update()
    {
        shoot=_playerInput.actions["Shoot"].IsPressed();
        shoot1=_playerInput.actions["Shoot"].WasPressedThisFrame();
        if(timer>0)
        {
            timer -= Time.deltaTime/firerate;
        }
        if(isAuto)
        {
            if( shoot==true && timer<=0)
            {
                Shoot();
            }
        }
        else
        {
            if(shoot1==true && timer<=0)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet=Instantiate(bulletPrefab,bulletSpawnTransform.position,Quaternion.identity,GameObject.FindGameObjectWithTag("WorldObject").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward*bulletspeed,ForceMode.Impulse);
       // bullet.GetComponent<BulletControl>().damage=bulletdmg;

        timer=1;
    }
    /*void OnEnable()
    {
        controls.Movement.Enable();
    }
    void OnDisable()
    {
        controls.Movement.Disable();
    }*/
}
