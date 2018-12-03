using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    Transform enemy;
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<Transform> enemyTypes = new List<Transform>();
    [SerializeField] float spawnRate = 5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 5, spawnRate);

    }
	
    void Spawn() {
        int randEnemy = Random.Range(0, enemyTypes.Count);
        int randSpawn = Random.Range(0, spawnPoints.Count);
        
        Instantiate(enemyTypes[randEnemy], spawnPoints[randSpawn].position, Quaternion.identity);
    }
}
