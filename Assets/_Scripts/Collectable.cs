using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponentInParent<Inventory>().Pickup(this);
            //tODo Play audio cue and update UI/Model
            this.gameObject.SetActive(false);
        }
    }
}
