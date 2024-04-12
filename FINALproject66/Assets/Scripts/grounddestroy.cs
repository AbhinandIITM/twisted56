using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    public float damageRate = 10f;
    public float nextDamageTime = 60f;

    void Update()
    {
        // Start applying damage after 10 seconds
        if (Time.time >= nextDamageTime)
        {
            // Iterate through all colliders currently in contact with the floor
            Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation);

            foreach (Collider collider in colliders)
            {
                // Check if the colliding object has a specific tag or meets other conditions
                if (collider.CompareTag("Floor") || collider.CompareTag("invertgravity")||collider.CompareTag("moregravity")||collider.CompareTag("lessgravity"))
                {
                    // Apply damage to the floor or perform other actions as needed
                    ApplyDamage(collider.gameObject);
                }
            }

            // Set the next damage time for the next iteration
            nextDamageTime += damageRate;
        }
    }

    private void ApplyDamage(GameObject floor)
    {
        // Your damage logic goes here
        // e.g., decrease floor health or trigger some damage-related behavior
        Debug.Log("Applying damage to the floor!");

        // Optional: You can add more logic here, such as destroying the floor
        Destroy(floor);
    }
}
