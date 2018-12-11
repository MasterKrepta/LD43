using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Slider playerHealthBar;

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
            GetComponent<AudioSource>().Play();
            CurrentHealth -= dmg;
            playerHealthBar.value = (currentHealth / maxHealth);
            if (CurrentHealth <= 0) {
                Die();
            }
            Invoke("ResetInvul", invulReset);
        }
    }

    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
        gameOverScreen.SetActive(false);
    }

    void ResetInvul() {
        invulnerable = false;
    }
}
