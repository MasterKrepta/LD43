using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable{
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] float maxHealth;

    [SerializeField] bool invulnerable = false;
    [SerializeField] float invulReset = 2f;
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
        GameManager.PlayerDied(gameOverScreen);
    }

    public void TakeDamage(float dmg, Vector3 dir) {
        if (!invulnerable) {
            invulnerable = true;
            Debug.Log(this.name + "takes damage: health remaining = : " + CurrentHealth);
            CurrentHealth -= dmg;
            if (CurrentHealth <= 0) {
                Die();
            }
            Invoke("ResetInvul", invulReset);
        }
        
    }

    // Use this for initialization
    void Awake () {
        CurrentHealth = MaxHealth;
        gameOverScreen.SetActive(false);
    }

    void ResetInvul() {
        invulnerable = false;
    }
}
