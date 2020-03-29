using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public Animator anim;
    private bool isCrouching;
    public bool canCrouch = false;

    public bool soundPlayed;
    public AudioClip myClip;

    private void Start() {
        isCrouching = false;
        soundPlayed = false;
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = myClip;
        
    }
    
    private void Update() {
        if (canCrouch) {
            isCrouching = Input.GetKey(KeyCode.LeftShift);
            anim.SetBool("isCrouch", isCrouching);
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                Debug.Log("CROUCH TA MERE");
                this.GetComponent<AudioSource>().Play();
                soundPlayed = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                soundPlayed = false;
            }
        }
    }

}
