using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {

    
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }

    void TakeDamage(float dmg);

    void Die();
}
