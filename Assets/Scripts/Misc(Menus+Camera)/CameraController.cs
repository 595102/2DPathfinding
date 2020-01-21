using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    //This allows the camera to know the loaction of the player 
    private Vector3 offset;
    //This allows the camera to know the distance between the player and the camera

    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    //This stores a value to ofset by finding the distance between the camera and player

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
