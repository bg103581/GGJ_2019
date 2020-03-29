using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life = 50f;

    public bool soundPlayed;
    public AudioClip myClip;

    void Start() {
        soundPlayed = false;
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = myClip;
    }

    private void Update()
    {
        if (life <= 0)
        {
            if (!soundPlayed) {
                GetComponent<AudioSource>().Play();
                soundPlayed = true;
            } else {
                Destroy(gameObject);
            }
            
        }
    }
}
