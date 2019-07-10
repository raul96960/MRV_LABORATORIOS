using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {
	//public AudioClip hitSound; con este no funciona bota error no se por que?
	public AudioClip hitSound;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider other) {
		//audio.Play ();
		audio.PlayOneShot (hitSound);
	}
}
