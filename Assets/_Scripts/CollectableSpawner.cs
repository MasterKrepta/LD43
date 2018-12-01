using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour {

    [SerializeField] List<Collectable> partsToSpawn = new List<Collectable>();
    int index = 0;
    // Use this for initialization
	void Start () {
        foreach (Collectable c in partsToSpawn) {
            c.gameObject.SetActive(false);
        }
        SpawnNextPart();
	}
	
    public void SpawnNextPart() {
        partsToSpawn[index].gameObject.SetActive(true);
    }

    public void IncrementSpawnIndex() {
        if (index == partsToSpawn.Count) {
            return;
        } 
        index++;
    }
}
