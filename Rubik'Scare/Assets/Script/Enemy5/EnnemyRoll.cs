using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRoll : MonoBehaviour
{
    public float speed = 12.0f;
    private GameObject player;
    private Animator anim;
    public bool Roll = false;
    private RaycastHit wall;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Roll)
        {
            transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
        }
        
    }
}
