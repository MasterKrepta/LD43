using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    [SerializeField] float globalGravity = -9.81f;

    Rigidbody rb;
    [SerializeField] bool isGrounded;
    [Range (1,15)]
    [SerializeField]float jumpForce = 10f;
    

    [SerializeField] float fallMulti = 2.5f;
    [SerializeField] float lowMulti = 2f;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        
        SetGravity();
        
    }

    private void FixedUpdate() {
        SetGravity();//FOR TESTING
        Debug.Log(Physics.gravity.y + " is our gravity");
        //Debug.Log(rb.velocity.y);
        if (Input.GetButton("Jump") && isGrounded){
            rb.velocity = Vector3.up * jumpForce;

            ////Better jumping
            if (rb.velocity.y < 0) {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
                Debug.Log("fallmulti");
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowMulti - 1) * Time.deltaTime;
                Debug.Log("lowMulti");
            }
            isGrounded = false;
        }
    }

    void OnCollisionStay() {
        isGrounded = true;
    }

    void SetGravity() {
        if (globalGravity > 0)
            globalGravity *= -1;
        Physics.gravity = new Vector3(0, globalGravity, 0);
    }
}
