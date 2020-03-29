using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float maxDist = 20f;
    public float minDist = 15f;
    public float speed = 5f;
    private GameObject player;
    private Animator anim;

    private Rigidbody rb;
    private RaycastHit wall;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(transform.position, player.transform.position, out wall))
        {
            if (wall.transform.tag != "Wall")
            {
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) < minDist)
                {

                    transform.LookAt(player.transform);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    anim.SetBool("IsRun", true);
                }
                else
                {
                    anim.SetBool("IsRun", false);
                }
            }
        }
    }
}
