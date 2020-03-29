using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : MonoBehaviour
{
    private GameObject player;
    private float damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = player.GetComponent<Player_Controller>().damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Life>().life -= damage;
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "RollingEnemy")
        {
            other.gameObject.GetComponent<Life>().life -= damage;
            Destroy(gameObject);
        }
    }
}
