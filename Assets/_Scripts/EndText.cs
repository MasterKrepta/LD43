using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndText : MonoBehaviour {

    [SerializeField] TMP_Text dialogText;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    [SerializeField] Button quit;
    int index = -1;
    List<string> transmissions = new List<string>();

    private void Start() {
        Time.timeScale = 1;
        //FINAL
        transmissions.Add("Systems online. We are heading home! Thank you for your sacrifice.");
        
        transmissions.Add("BREAK");
        GetNextLine();
    }

    public void GetNextLine() {
        index++;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText() {
        yield return new WaitForSeconds(1f);
        dialogText.text = "";
        if (transmissions[index] == "BREAK") {
            StartCoroutine(ShowQuit());
            yield break;
        }
        foreach (char c in transmissions[index]) {
            yield return new WaitForSeconds(typingSpeed);
            dialogText.text += c;
        }
        yield return new WaitForSeconds(displayTime);
        GetNextLine();
    }
    IEnumerator ShowQuit() {
        yield return new WaitForSeconds(5);
        quit.gameObject.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
