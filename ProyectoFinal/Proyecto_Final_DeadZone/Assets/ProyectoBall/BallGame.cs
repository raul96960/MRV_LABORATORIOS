using UnityEngine;
using System.Collections;
public class BallGame : MonoBehaviour {
	public GameObject ball;
	public float startHeight = 10f;
	public float fireInterval = 5f;
	private float nextBallTime = 0.0f;
	private GameObject activeBall;
	private Transform head;
	private AudioSource audio;
	void Start () {
		head = Camera.main.transform;
		audio = GetComponent<AudioSource> ();
	}
	void Update () {
		if (Time.time > nextBallTime) {
			nextBallTime = Time.time + fireInterval;
			audio.Play ();
			Vector3 position = new Vector3( head.position.x,
				startHeight, head.position.z + 0.2f );
			activeBall = Instantiate( ball, position,
				Quaternion.identity ) as GameObject;
		}
	}
}