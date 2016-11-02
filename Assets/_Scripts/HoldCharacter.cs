using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Baby")
			coll.transform.parent.parent = gameObject.transform.parent;
	}
	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Baby")
			coll.transform.parent.parent = null;
	}
}
