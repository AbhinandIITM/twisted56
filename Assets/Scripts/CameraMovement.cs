using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Update()
    {
        //transform.position = (player.position + offset - transform.position)*.02f + transform.position;
        transform.position=player.position+offset;
    }
}