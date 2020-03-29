using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy2Script : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 vectBullet;
    public float speed;
    public float damage;
    private GameObject player;


    // Start is called before the first frame update
    void Start() {
        speed = 10.0f;
        rb = GetComponent<Rigidbody>();
        vectBullet = transform.forward;
        player = GameObject.FindGameObjectWithTag("Player");

        rb.AddForce(vectBullet * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            player.GetComponent<Stat>().mentalLife -= damage;
        }
        Destroy(gameObject);
    }
}
