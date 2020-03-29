using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public float mentalLife = 100f;

    public float mentalLifeMax = 100f;

    public bool isFollowed = false;

    public bool[] StatUp = {false, false, false, false};

    public bool win;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mentalLife = 100;
        mentalLifeMax = 100;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStat();
        if (mentalLife == 0) {
            Debug.Log("DEAD");
        }

    }

    void UpdateStat()
    {
        if (StatUp[0])
        {
            gameObject.GetComponent<Player_Controller>().damage = 50;
        }
        if (StatUp[1])
        {
            gameObject.GetComponent<Crouch>().canCrouch = true;
        }
        if (StatUp[2])
        {
            gameObject.GetComponent<Jump>().jumpNumber = 2;
        }
        if (StatUp[3])
        {
            gameObject.GetComponent<Player_Controller>().speed = 10;
        }
    }
}
