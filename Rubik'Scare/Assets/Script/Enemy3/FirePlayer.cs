using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public float seconds = 2f;
    public GameObject projectile;
    public float spawnDistance;
    public float rotationSpeed = 5f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FireProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        var lookPos = player.gameObject.transform.position - transform.position;
        lookPos.y = transform.position.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPos), Time.deltaTime*rotationSpeed);
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
