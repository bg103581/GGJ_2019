using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDonut : MonoBehaviour
{
    public GameObject projectile;
    
    public float spawnDistance = 1f;
    public float seconds = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireProjectile());
    }

    IEnumerator FireProjectile()
    {
        while (true)
        {
            Instantiate(projectile, transform.position + spawnDistance * transform.forward, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
    }
}
