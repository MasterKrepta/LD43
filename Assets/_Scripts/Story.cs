using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Story : MonoBehaviour {

    CollectableSpawner spawner;
    public bool StoryBegun = false;
    List<string> transmissions = new List<string>();
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int index = -1;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    private void Start() {
        spawner = FindObjectOfType<CollectableSpawner>();
        dialogBox.SetActive(false);
        index = -1;
        transmissions.Clear();

        //First collectable.
        transmissions.Add("Oh thank god you arrived, my systems are not beyond repair, but I cannot contact Earth.");
        transmissions.Add("My scanner range is limited, I need more solar cells to power up enough to scan further");
        transmissions.Add("BREAK");

        //Second
        transmissions.Add("Thats better, Analysing.. I think I have something.");
        transmissions.Add("I have detected a replacement antenna nearby, I will activate a beacon. Please hurry");
        transmissions.Add("BREAK");

        //Third
        transmissions.Add("Thats better, i am getting Telementry Data, but I have lost control over my engines");
        transmissions.Add("I have detected a damaged, but salvagable circuit board that should still be intact, just over that ridge");
        transmissions.Add("BREAK");

        //Fourth
        transmissions.Add("Finally! I have the data I need to plan my return, and the ability to take off, The spare fuel Tanks should be somewhere around here.");
        transmissions.Add("BREAK");

        //Fifth
        transmissions.Add("My systems are almost back online, I just need a replacement power core and I can head back home");
        transmissions.Add("I know it's a lot to ask, but a jump from your battery is the only hope I have for getting back home");
        transmissions.Add("BREAK");

        //FINAL
        transmissions.Add("Thank you for your sacrifice");
        transmissions.Add("BREAK");
        //TODO display end game scene here. 
    }

    public void GetNextLine() {
        
        index++;
        dialogBox.SetActive(true);
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText() {
        yield return new WaitForSeconds(1f);
        dialogText.text = "";
        if (transmissions[index] == "BREAK") {
            dialogBox.SetActive(false);
            spawner.SpawnNextPart();
            yield break;
        }
        foreach (char c in transmissions[index]) {
            yield return new WaitForSeconds(typingSpeed);
            dialogText.text += c;
        }
        yield return new WaitForSeconds(displayTime);
        GetNextLine();
    }

    private void Update() {
        //if (Input.GetKeyDown(KeyCode.T)){
        //    GetNextLine();
        //}
    }
}
