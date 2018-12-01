using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Transform myTransform;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;

    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
	}

    void FixedUpdate() {
        Vector3 movement = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);
        myTransform.Translate(movement * moveSpeed * Time.deltaTime);
        myTransform.Rotate(rotation * rotSpeed * Time.deltaTime);
    }
}
