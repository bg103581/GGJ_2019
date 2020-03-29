using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHealth : MonoBehaviour
{
    public float maxLife;
    public Image maxLifeBar;


    void Start() {
        maxLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Stat>().mentalLifeMax;
        maxLifeBar = GetComponent<Image>();
    }

    void Update() {
        maxLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Stat>().mentalLifeMax;
        minusMaxLife();
    }
    public void minusMaxLife() {
        maxLifeBar.fillAmount = maxLife / 100;
    }
}
