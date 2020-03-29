using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentLife;
    public float maxLife;
    public Image lifeBar;


    void Start() {
        currentLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Stat>().mentalLife;
        maxLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Stat>().mentalLifeMax;
        lifeBar = GetComponent<Image>();
    }

    void Update() {
        currentLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Stat>().mentalLife;
        maxLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Stat>().mentalLifeMax;
        minusLife();
    }
    public void minusLife() {
        lifeBar.fillAmount = currentLife / 100;
    }
    
}
