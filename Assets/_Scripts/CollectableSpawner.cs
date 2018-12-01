using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour {

    [SerializeField] List<Collectable> partsToSpawn = new List<Collectable>();
    int index = 0;

    Story story;
    // Use this for initialization
	void Start () {
        story = FindObjectOfType<Story>();
        foreach (Collectable c in partsToSpawn) {
            c.gameObject.SetActive(false);
        }
        //SpawnNextPart();
	}
	
    public void SpawnNextPart() {
        if (index > partsToSpawn.Count) {
            Debug.LogWarning("Index is wrong in spawn next part");
            return;
        }
        partsToSpawn[index].gameObject.SetActive(true);
    }

    public void IncrementSpawnIndex() {
        if (index == partsToSpawn.Count) {
            return;
        } 
        index++;
    }
}
