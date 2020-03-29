using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PNJinteract : MonoBehaviour
{
    private GameObject player;
    private Vector3 dir;
    public float rotationSpeed, moveSpeed, dist;
    public bool isFollowing;
    private RaycastHit wall;
    public float offset;
    public bool isFollowed = false;
    private GameObject GOFollow;
    private GameObject[] PNJ;
    private int i = 0;
    private float distY;
    
    private static int count;

    public bool soundPlayed;
    public AudioClip myClip;

    private void Start() {
        rotationSpeed = 6;
        moveSpeed = 6;

        isFollowing = false;
        player = GameObject.FindGameObjectWithTag("Player");
        count = 0;

        PNJ = GameObject.FindGameObjectsWithTag("PNJ");

        soundPlayed = false;
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = myClip;
    }

    private void Update() {
        
        dist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        
        if (Input.GetKeyDown(KeyCode.A) && (dist <= 2.0f) && !isFollowing) {

            count += 1;

            this.GetComponent<AudioSource>().Play();
            soundPlayed = true;

            if (count == 5) {
                player.GetComponent<Stat>().win = true;
                player.GetComponent<Stat>().isFollowed = false;
                SceneManager.LoadScene("HUB");
            }


            if (!(player.GetComponent<Stat>().isFollowed)) {
                GOFollow = player;
                player.GetComponent<Stat>().isFollowed = true;
                this.gameObject.GetComponent<PNJinteract>().isFollowing = true;
                Debug.Log("Player");
            } else {
                
                PNJ = GameObject.FindGameObjectsWithTag("PNJ");
                Debug.Log("PNJ Lenght" + PNJ.Length);
                for(i=0; i<PNJ.Length; i++) {
                    if(PNJ[i].gameObject.GetComponent<PNJinteract>().isFollowing && !(PNJ[i].gameObject.GetComponent<PNJinteract>().isFollowed)) {
                        GOFollow = PNJ[i].gameObject;
                    }
                }

                GOFollow.GetComponent<PNJinteract>().isFollowed = true;
                isFollowing = true;
                
            }
        }

        soundPlayed = false;

        if (isFollowing) {
            dir = GOFollow.transform.position - transform.position;

            // Rotate towards player
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            if (dir.magnitude >= 1.5f) {
                
                // Move forward at specified speed
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                
            }

            if (dist >= 5.0f)
            {
                teleport();
            }
            if (Physics.Linecast(transform.position, GOFollow.transform.position, out wall)) {
                if (wall.transform.tag == "Wall") {
                    teleport();
                }
            }
        }
    }

    private void teleport() {
        transform.position = new Vector3(GOFollow.transform.position.x, GOFollow.transform.position.y, GOFollow.transform.position.z - 0.5f);
    }
}
