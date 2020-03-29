using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnPlayer : MonoBehaviour
{

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
