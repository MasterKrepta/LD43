using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    
    Transform myTransform;
    [SerializeField] float moveSpeed;
    float baseMoveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] bool canBoost = true;
    [SerializeField] float boostTime;

    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
        baseMoveSpeed = moveSpeed;
	}
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameManager.TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            Sacrifice sacrifice = FindObjectOfType<Sacrifice>();
            sacrifice.SelectSacrifice();
        }
    }

    void FixedUpdate() {
        if (!GameManager.IsPaused) {

            Vector3 movement = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
            Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);
            if (GameManager.BoostIsEnabled) {
                if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost) {
                    baseMoveSpeed = moveSpeed; // For testing only incase we change mid play
                    canBoost = false;
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
        moveSpeed = baseMoveSpeed;
        canBoost = true;
    }
}
