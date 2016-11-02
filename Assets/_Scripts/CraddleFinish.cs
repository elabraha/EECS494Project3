using UnityEngine;
using System.Collections;

public class CraddleFinish : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider C) {
		
		if (C.gameObject.tag == "Baby") {
			WinGameEvent.G.babySleep++;
			DestroyObject (C.gameObject);
		}
	}
}
