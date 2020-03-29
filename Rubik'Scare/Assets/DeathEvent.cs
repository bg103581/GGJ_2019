﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player.GetComponent<Stat>().mentalLife -= 100;
        }
    }
}
