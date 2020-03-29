using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTouchPlayer : MonoBehaviour
{
    public float damage=50f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Stat>().mentalLife -= damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag != "Ground")
        {
            Destroy(gameObject);
        }
    }
}
