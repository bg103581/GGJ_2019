using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public float seconds = 2f;
    public bool healing = false;
    private GameObject player;

    private float nLife;

    private float nLifeMax;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            healing = true;
            Debug.Log("Coucou");
            StartCoroutine(Healing());
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            healing = false;
            StopCoroutine(Healing());
        }
    }


    IEnumerator Healing()
    {
        while (true)
        {
            Debug.Log("Test");
            if (healing)
            {
                nLife = player.GetComponent<Stat>().mentalLife;
                nLifeMax = player.GetComponent<Stat>().mentalLifeMax;
                if (nLife < nLifeMax)
                {
                    nLife = player.GetComponent<Stat>().mentalLife + 20;
                    player.GetComponent<Stat>().mentalLife = nLife;
                }
                else if (player.GetComponent<Stat>().mentalLife > player.GetComponent<Stat>().mentalLifeMax)
                {
                    player.GetComponent<Stat>().mentalLife = player.GetComponent<Stat>().mentalLifeMax;
                }
                else
                {
                    nLifeMax = player.GetComponent<Stat>().mentalLifeMax - 1;
                    player.GetComponent<Stat>().mentalLifeMax = nLifeMax;
                    player.GetComponent<Stat>().mentalLife = player.GetComponent<Stat>().mentalLifeMax;
                }
            }
            yield return new WaitForSeconds(seconds);
        }
    }
}
