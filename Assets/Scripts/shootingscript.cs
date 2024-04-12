using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingscript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletHole;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 bulletSpawnPoint = bulletHole.position;
            Quaternion bulletRotation = bulletHole.rotation;

            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint, bulletRotation);
            
            // Retrieve the Rigidbody component from the bullet prefab
            Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();

            if (bulletRb != null)
            {
                // Apply force to the bullet in the forward direction of the bulletHole
                bulletRb.AddForce(bulletHole.forward * bulletSpeed, ForceMode.Impulse);
            }
            else
            {
                Debug.LogError("Bullet prefab does not have a Rigidbody component.");
            }
        }
    }
}
