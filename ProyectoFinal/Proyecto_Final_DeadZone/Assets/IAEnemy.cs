using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemy : MonoBehaviour {
	
	public GameObject targetPersonaje;
	public NavMeshAgent agent;

	public float distance;

	// Use this for initialization
	//void Start () {

	//}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(targetPersonaje.transform.position,transform.position) < distance){
			agent.SetDestination (targetPersonaje.transform.position);
			agent.speed = 3;
		}else{
			agent.speed = 0;
		}
		
	}
}
