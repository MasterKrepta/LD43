using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour {

    [SerializeField]Image boost;
    [SerializeField] Image jump;
    [SerializeField] Image gun;
    [SerializeField] Image sword;

    [SerializeField] Sprite boostDis;
    [SerializeField] Sprite jumpDis;
    [SerializeField] Sprite gunDis;
    [SerializeField] Sprite swordDis;

    public void BoostDisabled() {
        boost.sprite = boostDis;
    }
    public void JumpDisabled() {
        jump.sprite = jumpDis;
    }
    public void GunDisabled() {
        gun.sprite = gunDis;
    }

    public void SwordDisabled() {
        sword.sprite = swordDis;
    }
}
