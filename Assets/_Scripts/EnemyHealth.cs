using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable {

    [SerializeField] float maxHealth;
    public float MaxHealth {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    [SerializeField] float currentHealth;
    public float CurrentHealth {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public void Die() {
        Debug.Log(gameObject.name + " is dead");
        Destroy(gameObject);
    }

    public void TakeDamage(float dmg) {
        CurrentHealth -= dmg;
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
