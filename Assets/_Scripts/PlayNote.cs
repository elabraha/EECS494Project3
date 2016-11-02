using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayNote : MonoBehaviour {
	AudioSource audio;
//	private Vector3 offset;
	public int onwhat;

	void Start() {
		audio = GetComponent <AudioSource> ();
	}

	// Use this for initialization
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Baby") {
			WinGameEvent.G.uptrigger ();
			WinGameEvent.G.played.Add (onwhat);
			print (onwhat);
			audio.Play ();
		}
//		if (coll.gameObject.tag == "GridObj") {
//			print ("hello??");
//			audio = coll.gameObject.GetComponent <AudioSource> ();
//		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Baby") {
			audio.Stop ();
		}
	}
		
}
