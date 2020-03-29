using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("HUB");
    }
    
    public void Settings() {
        SceneManager.LoadScene("Settings");
    }

    public void Quit() {
        Application.Quit();
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Instructions() {
        SceneManager.LoadScene("Instructions");
    }
}
