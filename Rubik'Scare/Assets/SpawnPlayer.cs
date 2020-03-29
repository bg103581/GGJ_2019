using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    public Material materialCubal;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.gameObject.transform.position= gameObject.transform.position;
        foreach (Transform child in player.transform)
        {
            child.gameObject.GetComponent<MeshRenderer>().material = materialCubal;
        }
    }

    
}
