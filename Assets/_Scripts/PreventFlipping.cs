using System;
using System.Collections;
using UnityEngine;

public class PreventFlipping : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] GameObject comObject;
    [SerializeField] Vector3 com;
    float baseGravity = Physics.gravity.y;
    [SerializeField] float modGravity = Physics.gravity.y * 2;
    [SerializeField] float xRot = 30;
    [SerializeField] float yRot = 30;
    [SerializeField] float zRot = 30;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        com = comObject.transform.localPosition;
        rb.centerOfMass = com;
        Debug.Log(baseGravity);
       
    }

    private void FixedUpdate() {
        //if (transform.rotation.eulerAngles.x > xRot) {
        //    transform.rotation = Quaternion.identity;
        //}
        //if (transform.rotation.eulerAngles.y > yRot) {
        //    transform.rotation = Quaternion.identity;
        //}
        //if (transform.rotation.eulerAngles.z > zRot) {
        //    transform.rotation = Quaternion.identity;
        //}
    }
}
