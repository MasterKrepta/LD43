using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField] Transform barrel;
    [SerializeField] Transform bullet;
    [SerializeField]float fireRate = .5f;
    bool canFire = true;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.IsPaused && GameManager.GunIsEnabled) {
            //if(Input.GetKey(KeyCode.Return) && canFire) {
            if (Input.GetMouseButton(0) && canFire) {
                canFire = false;
                StartCoroutine(Resetfire());
                Instantiate(bullet, barrel.position, barrel.rotation);
            }
        }
	}

    IEnumerator Resetfire() {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
