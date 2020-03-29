using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerFix : MonoBehaviour
{
    public float damage=2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Stat>().mentalLife -= damage;
            Destroy(gameObject);
        }
    }
}
