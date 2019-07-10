using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject targetPersonaje;
	public NavMeshAgent agent;
	// Use this for initialization

	public float distance;


	//void Start () {
	//}
	
	// Update is called once per frame
	void Update () {
		//float personajeDistancia=Vector3.Distance(targetPersonaje.transform.position,transform.position);
		if(Vector3.Distance(targetPersonaje.transform.position,transform.position) < distance){
			agent.SetDestination (targetPersonaje.transform.position);
			agent.speed = 3;
		}else{
			agent.speed = 0;
		}
	}
}
