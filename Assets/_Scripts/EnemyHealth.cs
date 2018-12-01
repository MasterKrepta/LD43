using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamagable {

    [SerializeField] float maxHealth;
    [SerializeField] float knockbackForce;
    NavMeshAgent agent;
    
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

    public void TakeDamage(float dmg, Vector3 dir) {
        CurrentHealth -= dmg;
        Debug.Log("Hit");
        Knockback(dir);
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Knockback(Vector3 dir) {

        agent.velocity = dir * knockbackForce;
        
    }
}
