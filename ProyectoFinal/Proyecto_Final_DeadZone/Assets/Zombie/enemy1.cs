using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy1 : MonoBehaviour {

	public Transform player;
    public NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		player =	GameObject.FindWithTag ("usuario").transform;
		nav = GetComponent<NavMeshAgent> ();


	
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (player.position);
	}
}
