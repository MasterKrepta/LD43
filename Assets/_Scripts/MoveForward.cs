using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 5f;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        //transform.position += (transform.forward * speed) * Time.deltaTime;
        Destroy(this.gameObject, lifetime);
	}
}
