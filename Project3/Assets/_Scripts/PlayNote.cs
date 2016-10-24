using UnityEngine;
using System.Collections;

public class PlayNote : MonoBehaviour {
	AudioSource audio;

	void OnTriggerStay(Collider coll) {
		//print ("anycolls??");
		if (coll.gameObject.tag == "Gridobj") {
			print ("hello??");
			audio = coll.gameObject.GetComponent <AudioSource> ();
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Note") {
			audio.Play ();
		}
//		if (coll.gameObject.tag == "GridObj") {
//			print ("hello??");
//			audio = coll.gameObject.GetComponent <AudioSource> ();
//		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Note") {
			audio.Stop ();
		}
	}
		
}
