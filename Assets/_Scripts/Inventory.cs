using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Story story;
    public List<Collectable> collectables = new List<Collectable>();


    private void Awake() {
        story = FindObjectOfType<Story>();
        story.StoryBegun = false;
    }
    public void Pickup(Collectable c) {
        collectables.Add(c);
    }

    public void DropOff(Collectable c, Inventory other) {
        this.collectables.Add(c);
        other.collectables.Remove(c);
        story.GetNextLine();
        CollectableSpawner spawner = FindObjectOfType<CollectableSpawner>();
        
        spawner.IncrementSpawnIndex();
        spawner.SpawnNextPart();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (!story.StoryBegun) {
                story.StoryBegun = true;
                story.GetNextLine();
            }
            Inventory inventory = other.GetComponentInParent<Inventory>();
            if (inventory.collectables.Count > 0) {
                Sacrifice sacrifice = other.GetComponentInParent<Sacrifice>();
                sacrifice.SelectSacrifice();
                DropOff(inventory.collectables[0], inventory);
            }
            
        }
    }
}
