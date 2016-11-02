using UnityEngine;
using System.Collections;

public class ConePass : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
		print ("triggered"); 
		if (coll.gameObject.tag == "Baby") {
			print ("somethinghappened");
			print (GetComponent <Collider> ().gameObject.tag);
			Physics.IgnoreCollision (coll, GetComponent <Collider>());
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Baby")
			Physics.IgnoreCollision (coll, GetComponent <Collider>(), false);
	}
}
