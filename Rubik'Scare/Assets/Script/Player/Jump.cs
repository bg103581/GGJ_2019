using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public int jumpNumber = 1;
    private int myJumpNumber;
    public float jumpForce;
    public static bool isGrounded;
    Rigidbody rb;
    
    void Start()
    {
        myJumpNumber = 0;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2.5f, 0f);
    }
    
    void Update()
    {
        // Si on appuie sur espace, on commence le compteur des sauts
        if (Input.GetKeyDown(KeyCode.Space)) {
            myJumpNumber += 1;

            // Si on était au sol ou si le nombre de saut est <= au nombre de saut autorisé, le joueur saut
            if (isGrounded || (!isGrounded && (myJumpNumber <= jumpNumber))) {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
        }
    }

    // Pour savoir si on est au sol
    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            myJumpNumber = 0;
        }
    }

    // Pour savoir si on quitte le sol
    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            myJumpNumber = 1;
        }
    }
}
