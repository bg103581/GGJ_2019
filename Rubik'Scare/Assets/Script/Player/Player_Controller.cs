using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float speed;
    public float rotationSpeed = 200.0f;
    //variables pour les bullets
    public GameObject bullet;
    public float spawnDistance;
    public float range;
    public float fireRate;
    public float damage;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private Animator anim;
    private Vector3 newRotation;
    

    //variables pour le fire rate
    private float nextFire = 0;

    private void Start() {
        nextFire = 0.5f;
        spawnDistance = 1f;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update ()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = -Input.GetAxisRaw("Vertical");
        if (moveVertical == 0 && moveHorizontal == 0)
        {
            anim.SetBool("IsRun",false);
        }
        else
        {
            anim.SetBool("IsRun", true);
            newRotation = movement;
        }
        movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        transform.rotation = Quaternion.LookRotation(newRotation);
  
  
        transform.Translate (movement * speed * Time.deltaTime, Space.World);
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position + spawnDistance * transform.forward, transform.rotation);
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "PNJ") {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
