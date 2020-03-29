using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCompleteController : MonoBehaviour
{
    public GameObject player;
    public float cameraDistance = 5.0f;

    public Quaternion rotation;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate ()
    {
        transform.LookAt(player.transform);
    }
}
