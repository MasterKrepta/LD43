using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamagable {

    [SerializeField] MeshRenderer renderBody;
    Color original;
    [SerializeField] float maxHealth;
    [SerializeField] float knockbackForce;
    NavMeshAgent agent;
    Vector3 dir;
    [SerializeField] bool knockback = false;
    
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
        Destroy(gameObject);
    }

    public void TakeDamage(float dmg, Vector3 directionHit) {
        StartCoroutine(FlashColor());
        dir = directionHit;
        CurrentHealth -= dmg;
        GetComponent<AudioSource>().Play();
        knockback = true;
        StartCoroutine(Knockback());
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    IEnumerator FlashColor() {
        renderBody.material.color = Color.red;
        yield return new WaitForSeconds(1);
        renderBody.material.color = original;
    }

    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
        original = renderBody.material.color;
        agent = GetComponent<NavMeshAgent>();
	}
	
	IEnumerator Knockback() {
        agent.angularSpeed = 0;
        agent.acceleration = 20;
        
        yield return new WaitForSeconds(0.3f);
        knockback = false;
        agent.angularSpeed = 120;
        agent.acceleration = 8;

    }

    private void FixedUpdate() {
        if (knockback) {
            agent.velocity = dir * knockbackForce;
        }
    }

}
