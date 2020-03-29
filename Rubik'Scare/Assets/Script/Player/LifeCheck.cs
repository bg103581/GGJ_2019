using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCheck : MonoBehaviour
{
    private GameObject HUB;
    private float playerLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLife = gameObject.GetComponent<Stat>().mentalLife;
        if (playerLife <= 0.0f)
        {
            HUB = GameObject.FindGameObjectWithTag("HUB");
            Destroy(HUB);
            Destroy(gameObject);
            SceneManager.LoadScene("HUB");
        }
    }
}
