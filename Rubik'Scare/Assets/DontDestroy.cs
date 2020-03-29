using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public bool[,,] house ={{{false,false,false},{false,false,false},{false,true,true}},
        {{false,false,false},{false,false,false},{false,true,false}},
        {{false,false,false},{false,false,false},{false,false,false}}};

    public int count = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
