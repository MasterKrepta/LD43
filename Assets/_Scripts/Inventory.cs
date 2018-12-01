using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Collectable> collectables = new List<Collectable>();
    
    public void Pickup(Collectable c) {
        collectables.Add(c);
    }

    public void DropOff(Collectable c, Inventory other) {
        this.collectables.Add(c);
        other.collectables.Remove(c);
        CollectableSpawner spawner = FindObjectOfType<CollectableSpawner>();
        spawner.IncrementSpawnIndex();
        spawner.SpawnNextPart();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            
            Inventory inventory = other.GetComponentInParent<Inventory>();
            if (inventory.collectables.Count > 0) {
                Sacrifice sacrifice = other.GetComponentInParent<Sacrifice>();
                sacrifice.SelectSacrifice();
                DropOff(inventory.collectables[0], inventory);
            }
            
        }
    }
}
