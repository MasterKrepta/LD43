using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    
    Transform myTransform;
    
    [SerializeField] float moveSpeed;
    float baseMoveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField]bool isGrounded;
    RoverController roverController;

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
        roverController = GetComponent<RoverController>();
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
        baseMoveSpeed = roverController.maxMotorTorque;
        boostGraphic.SetActive(false);
        rb.centerOfMass = new Vector3(0, -0.9f, 0);
	}
    private void Update() {

        isGrounded = IsGrounded();

        

        if (!canBoost) {
            timer += Time.deltaTime;
            boostSlider.value = (timer / (boostCoolDown + boostTime));
        }
        
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
            Vector3 physMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (GameManager.BoostIsEnabled) {
                if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost) {
                    boostGraphic.SetActive(true);
                    
                    //baseMoveSpeed = moveSpeed; // For testing only incase we change mid play
                    canBoost = false;
                    boostSlider.value = boostSlider.minValue;
                    StartCoroutine(BoostMode());
                }
            }
            //if (boostGraphic.activeInHierarchy) {
            //    Debug.Log("Boosting");
            //    rb.AddForce(transform.forward * boostSpeed);
            //}
            
            //if (isGrounded) {
            //    Debug.Log("we can move");
            //    rb.AddRelativeForce(movement * moveSpeed);
            //    rb.AddRelativeTorque(rotation * rotSpeed);
            //}
            
        }

    }

    IEnumerator BoostMode() {
        //moveSpeed = boostSpeed;
        roverController.maxMotorTorque = boostSpeed;
        yield return new WaitForSeconds(boostTime);
        boostGraphic.SetActive(false);
        roverController.maxMotorTorque = baseMoveSpeed;
        //moveSpeed = baseMoveSpeed;
        yield return new WaitForSeconds(boostCoolDown);
        timer = 0;
        canBoost = true;
    }

    bool IsGrounded() {
      
        return Physics.Raycast(groundCheck.position, -groundCheck.up, .2f);
    }

    //void OnDrawGizmosSelected() {

    //    Debug.DrawRay(groundCheck.position, -groundCheck.up, Color.red, 1);
    //}

}

