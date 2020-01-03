using UnityEngine;
using System.Collections;

//This script tells the camera to follow the players position in the game world.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        target = Player.transform;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
