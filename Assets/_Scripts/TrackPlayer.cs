using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]
public class TrackPlayer : MonoBehaviour {

    Transform player;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMove>().transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        agent.SetDestination(player.position);
	}
}
