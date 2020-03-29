using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 vectBullet;
    public float speed = 10.0f;
    private GameObject player;
    public float rangeMax;

    private float range;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        vectBullet = transform.forward;

        rb.AddForce(vectBullet * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(player.transform.position, transform.position);

        if (range > rangeMax) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
