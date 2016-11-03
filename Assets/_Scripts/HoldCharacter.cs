using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Baby") {
			if(gameObject.transform.parent.GetComponent<MovingBeam>().isupdown){
				Vector3 v = coll.gameObject.GetComponentInParent <Rigidbody>().velocity;
				v.y = 0.0f;
				coll.gameObject.GetComponentInParent <Rigidbody>().velocity = v;
			}

			coll.transform.parent.parent = gameObject.transform.parent;
		}
	}
	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Baby") {
			Vector3 v = coll.gameObject.GetComponentInParent <Rigidbody>().velocity;
			v.y = 0.0f;
			coll.gameObject.GetComponentInParent <Rigidbody>().velocity = v;
			coll.transform.parent.parent = null;
		}
	}
}
