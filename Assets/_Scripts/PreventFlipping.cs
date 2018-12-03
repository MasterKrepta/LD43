
using UnityEngine;

public class PreventFlipping : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] GameObject comObject;
    [SerializeField] Vector3 com;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        com = comObject.transform.localPosition;
        rb.centerOfMass = com;
    }

    
}
