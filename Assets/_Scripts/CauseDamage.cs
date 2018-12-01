using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        IDamagable damagable = other.GetComponentInParent<IDamagable>();
        if (damagable != null) {
            Vector3 hitDir = transform.position - other.transform.position;
            hitDir = hitDir.normalized;
            damagable.TakeDamage(1, hitDir);
        }
    }
}
