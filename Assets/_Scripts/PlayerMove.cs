using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    
    Transform myTransform;
    [SerializeField] float moveSpeed;
    float baseMoveSpeed;
    [SerializeField] float rotSpeed;

    [SerializeField] Slider boostSlider;
    [SerializeField] float boostSpeed;
    [SerializeField] bool canBoost = true;
    [SerializeField] float boostTime;
    [SerializeField] float boostCoolDown;
    [SerializeField] GameObject boostGraphic;
    float timer = 0;

    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
        baseMoveSpeed = moveSpeed;
        boostGraphic.SetActive(false);
	}
    private void Update() {
        
        if (!canBoost) {
            timer += Time.deltaTime;
            boostSlider.value = (timer / (boostCoolDown + boostTime));
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameManager.TogglePause();
        }
        //if (Input.GetKeyDown(KeyCode.Y)) {
        //    Sacrifice sacrifice = FindObjectOfType<Sacrifice>();
        //    sacrifice.SelectSacrifice();
        //}
    }

    void FixedUpdate() {
        if (!GameManager.IsPaused) {

            Vector3 movement = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
            Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);
            if (GameManager.BoostIsEnabled) {
                if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost) {
                    boostGraphic.SetActive(true);
                    baseMoveSpeed = moveSpeed; // For testing only incase we change mid play
                    canBoost = false;
                    boostSlider.value = boostSlider.minValue;
                    StartCoroutine(BoostMode());
                }
            }
            
            myTransform.Translate(movement * moveSpeed * Time.deltaTime);
            myTransform.Rotate(rotation * rotSpeed * Time.deltaTime);
        }

    }

    IEnumerator BoostMode() {
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(boostTime);
        boostGraphic.SetActive(false);
        moveSpeed = baseMoveSpeed;
        yield return new WaitForSeconds(boostCoolDown);
        timer = 0;
        canBoost = true;
    }
}
