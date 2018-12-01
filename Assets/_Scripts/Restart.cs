using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    [SerializeField]GameObject main;
    [SerializeField]GameObject howTo;
    public void RestartGame() {
        GameManager.IsPaused = false;
        SceneManager.LoadScene(1);
    }

    public void MainMenu() {
        main.SetActive(true);
        howTo.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void HowTo() {
        main.SetActive(false);
        howTo.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
        
    }
}
