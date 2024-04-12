//using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FloorPlacer : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject collectibleFloorPrefab;
    public int numberOfBuildings = 400;
    public float planeSize = 100f;
    GameObject player;
    GameObject player2;
    public Vector3 Spawn;
    bool isPlayerSpawned;
    bool isPlayer2Spawned;

    void Start()
    {
        player = GameObject.Find("Player");
        isPlayerSpawned = false;
        PlaceFloors();
    }

    void PlaceFloors()
    {
        for (int i = 0; i < numberOfBuildings; i++)
        {
            // Randomly generate position within the plane size
            float randomX = Random.Range(-planeSize / 2f, planeSize / 2f);
            float randomZ = Random.Range(-planeSize / 2f, planeSize / 2f);

            // Create a new floor at the randomly generated position
            int n = UnityEngine.Random.Range(5, 10);
            int m = UnityEngine.Random.Range(1, n + 1);
            int p =  UnityEngine.Random.Range(10, n + 1);
            int rotationFactor = Random.Range(1, 5);
            bool isOverlap = CheckOverlap(randomX, randomZ, n);

            
                for (float j = 0f; j < n ; j++)
                 if (!isOverlap){
                {
                    if (j == m)
                    {
                        GameObject collectibleFloor = Instantiate(collectibleFloorPrefab, new Vector3(randomX, j, randomZ), Quaternion.identity);
                        collectibleFloor.transform.rotation = Quaternion.Euler(0f, 90 * rotationFactor, 0f);
                      /*collectibleFloor.transform.position = new Vector3(randomX + (rotationFactor == 2 ? 1 : 0), j, randomZ + (rotationFactor == 1 ? 1 : 0));*/
if(rotationFactor == 1){
  
    collectibleFloor.transform.position = new Vector3(randomX, j, randomZ+3);
}
else if(rotationFactor == 2){
    collectibleFloor.transform.position = new Vector3(randomX+3, j, randomZ+3);
}

else if(rotationFactor == 3){
    collectibleFloor.transform.position = new Vector3(randomX+3, j, randomZ);
}
                        string[] collectibleTagArray = { "invertgravity", "moregravity", "lessgravity" };
                        int randomIndex = Random.Range(0, collectibleTagArray.Length);
                        Transform childTransform = collectibleFloor.transform.Find("collectible brick");
                        childTransform.gameObject.tag = collectibleTagArray[randomIndex];
                    }
                   /* else if (j == m-p)
                    {
                        GameObject collectibleFloor = Instantiate(collectibleFloorPrefab, new Vector3(randomX, j, randomZ), Quaternion.identity);
                        collectibleFloor.transform.rotation = Quaternion.Euler(0f, 90 * rotationFactor, 0f);
                      /*collectibleFloor.transform.position = new Vector3(randomX + (rotationFactor == 2 ? 1 : 0), j, randomZ + (rotationFactor == 1 ? 1 : 0));
if(rotationFactor == 1){
  
    collectibleFloor.transform.position = new Vector3(randomX, j, randomZ+3);
}
else if(rotationFactor == 2){
    collectibleFloor.transform.position = new Vector3(randomX+3, j, randomZ+3);
}

else if(rotationFactor == 3){
    collectibleFloor.transform.position = new Vector3(randomX+3, j, randomZ);
}
                        string[] collectibleTagArray = { "invertgravity", "moregravity", "lessgravity" };
                        int randomIndex = Random.Range(0, collectibleTagArray.Length);
                        Transform childTransform = collectibleFloor.transform.Find("collectible brick");
                        childTransform.gameObject.tag = collectibleTagArray[randomIndex];
                    }*/
                    else
                    {
                        Instantiate(floorPrefab, new Vector3(randomX, j, randomZ), Quaternion.identity);
                    }
                }
                }

                if (!isPlayerSpawned)
                {
                    player.transform.position = new Vector3(randomX, n + 2, randomZ);
                    isPlayerSpawned = true;
                }
            if (i == 2)
            {
                Spawn = new Vector3(randomX, n + 2, randomZ);

            }
        }
    }
    bool p2 = false;

    void Update()
    {
        player2 = GameObject.Find("Player Prefab(Clone)");
        if (player2 != null && p2 == false)
        {
           // Debug.Log("Player 2");
            player2.transform.position = Spawn;
            p2 = true;

        }
    }

    bool CheckOverlap(float x, float z, int height)
    {
        Collider[] colliders = Physics.OverlapBox(new Vector3(x, height/2 , z), new Vector3(6f, height/2 , 6f));

        // Check if there are any colliders
        return colliders.Length > 1;
    }
}
