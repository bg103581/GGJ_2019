using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 vectBullet;
    public float speed = 10.0f;
    private GameObject player;
    public float rangeMax = 10f;
    private Vector3 startPosition;

    private float range;
    // Start is called before the first frame update
    private void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        vectBullet = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(startPosition, transform.position);
        transform.Translate (vectBullet * speed * Time.deltaTime, Space.World);
        if (range > rangeMax) {
            Destroy(gameObject);
        }
    }
}
