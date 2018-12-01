using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sacrifice : MonoBehaviour {

    UIUpdate ui;

    [SerializeField]GameObject sacrificeMenu;
    [SerializeField] List<Button> buttons;
    
    [SerializeField] Button battery;
    // Use this for initialization
    void Start () {
        ui = FindObjectOfType<UIUpdate>();
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
            battery.interactable = true;
        }
    }

    public void GiveUpJump(Button button) {
        button.interactable = false;
        GameManager.JumpIsEnabled = false;
        ui.JumpDisabled();
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }

    public void GiveUpSword(Button button) {
        button.interactable = false;
        GameManager.SwordIsEnabled = false;
        ui.SwordDisabled();
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }

    public void GiveUpGun(Button button) {
        button.interactable = false;
        GameManager.GunIsEnabled = false;
        ui.GunDisabled();
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }
    public void GiveUpBoost(Button button) {
        button.interactable = false;
        GameManager.BoostIsEnabled = false;
        ui.BoostDisabled();
        GameManager.TogglePause();
        sacrificeMenu.SetActive(false);
    }
    public void EndGame() {
        Debug.Log("You Win. Display EndGame");
    }
}
