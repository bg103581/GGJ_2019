using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoHub : MonoBehaviour
{
    private GameObject newparent;
    // Start is called before the first frame update
    void Start()
    {
        newparent = GameObject.FindGameObjectWithTag("HUB");
        gameObject.transform.parent = newparent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
