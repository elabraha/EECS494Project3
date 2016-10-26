using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayNote : MonoBehaviour {
	AudioSource audio;
//	private Vector3 offset;
	int onwhat;

//	void OnMouseDown(){
//		print ("anything??");
//		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30.0f));
//	}
//
//	void OnMouseDrag(){
//		print ("no??");
//		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30.0f);
//		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
//		transform.position = cursorPosition;
//	}

	void OnTriggerStay(Collider coll) {
		//print ("anycolls??");
		if (coll.gameObject.tag == "Gridobj") {
			//print ("hello??");
			onwhat = int.Parse(coll.gameObject.name);
			audio = coll.gameObject.GetComponent <AudioSource> ();
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Note") {
			WinGameEvent.G.uptrigger ();
			WinGameEvent.G.played.Add (onwhat);
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
