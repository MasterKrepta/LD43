using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (transform.forward * speed) * Time.deltaTime;
        Destroy(this.gameObject, lifetime);
	}
}
