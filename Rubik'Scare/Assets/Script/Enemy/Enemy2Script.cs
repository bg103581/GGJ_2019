using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{

    public GameObject bulletEnemy2;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("shootPattern");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootPattern() {
        while(true) {
            Instantiate(bulletEnemy2, coin2.transform.position, transform.rotation * Quaternion.Euler(0, 45, 0));
            Instantiate(bulletEnemy2, coin3.transform.position, transform.rotation * Quaternion.Euler(0, 135, 0));
            Instantiate(bulletEnemy2, coin1.transform.position, transform.rotation * Quaternion.Euler(0, -45, 0));
            Instantiate(bulletEnemy2, coin4.transform.position, transform.rotation * Quaternion.Euler(0, -135, 0));

            yield return new WaitForSeconds(0.2f);
        }
    }
}
