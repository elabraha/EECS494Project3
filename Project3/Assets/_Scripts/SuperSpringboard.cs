using UnityEngine;
using System.Collections;

public class SuperSpringboard : MonoBehaviour {

	GameObject Note;
	bool moveobject = false;
	//Vector3 GRAV = new Vector3 (0.0f, -9.8f, 0.0f); 

	// Use this for initialization
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Note") {
			Note = coll.gameObject;
			moveobject = true;
			//print ("note collide"); 
		}
	}

	void Update() {
		if (Note && moveobject) {
			Note.GetComponent <Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.VelocityChange);
			//print ("add force");
			moveobject = false;
		}
	}
}
