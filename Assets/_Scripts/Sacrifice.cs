using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sacrifice : MonoBehaviour {

    [SerializeField]GameObject sacrificeMenu;
    [SerializeField] List<Button> buttons;
    
    [SerializeField] Button battery;
    // Use this for initialization
    void Start () {
        sacrificeMenu.SetActive(false);
        battery.interactable = false;
	}
	
	public void SelectSacrifice() {
        CheckForEndgame();
        GameManager.TogglePause();
        sacrificeMenu.SetActive(true);
    }

    private void CheckForEndgame() {
        int activeBtns = 0;
        foreach (Button b in buttons) {
            if (b.interactable == true) {
                activeBtns++;
            }
        }
        if(activeBtns == 0) {
            Debug.Log("Endgame Time");
            battery.interactable = true;
        }
    }

    public void GiveUpJump(Button button) {
        button.interactable = false;
        Debug.Log("Jump is gone");
        GameManager.JumpIsEnabled = false;
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }

    public void GiveUpSword(Button button) {
        button.interactable = false;
        Debug.Log("Sword is gone");
        GameManager.SwordIsEnabled = false;
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }

    public void GiveUpGun(Button button) {
        button.interactable = false;
        Debug.Log("Gun is gone");
        GameManager.GunIsEnabled = false;
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }
    public void GiveUpBoost(Button button) {
        button.interactable = false;
        Debug.Log("Boost is gone");
        GameManager.BoostIsEnabled = false;
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }
    public void EndGame() {
        Debug.Log("You Win. Display EndGame");
    }
}
