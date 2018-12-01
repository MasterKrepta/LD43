
using UnityEngine;

public class PreventFlipping : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] Vector3 com;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }

    
}
