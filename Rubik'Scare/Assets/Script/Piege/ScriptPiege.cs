using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPiege : MonoBehaviour
{

    public int type;
    public float damage;
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {

            player.GetComponent<Stat>().mentalLife -= damage;

            if (type == 1) {
                anim.SetBool("active1", true);
            } else if (type == 2) {
                anim.SetBool("active2", true);
            } else {
                anim.SetBool("active3", true);
            }
        }
    }
    

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {

            if (type == 1) {
                anim.SetBool("active1", false);
            } else if (type == 2) {
                anim.SetBool("active2", false);
            } else {
                anim.SetBool("active3", false);
            }
        }
    }

    /*private void OnTriggerEnter(Collider other) {
        Debug.Log("hello");
        if (other.tag == "Player") {

            if (type == 1) {
                anim.SetTrigger("active1");
            } else if (type == 2) {
                anim.SetTrigger("active2");
            } else {
                anim.SetTrigger("active3");
            }
        }
    }*/
}
