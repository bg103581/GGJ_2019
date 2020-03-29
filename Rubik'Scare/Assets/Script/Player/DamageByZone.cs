using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DamageByZone : MonoBehaviour
{
    public float seconds = 1f;
    public float damage;
    private bool isKillingFloor = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;

        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DamagePlayer());
        foreach(bool el in player.GetComponent<Stat>().StatUp) {
            if (el) {
                seconds += 0.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    IEnumerator DamagePlayer()
    {
        while(true)
        {
            Debug.Log(damage);
            player.gameObject.GetComponent<Stat>().mentalLife -= damage;
            yield return new WaitForSeconds(seconds);
        }
    }
}

