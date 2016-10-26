using UnityEngine;
using System.Collections;

public class SuperSpringboard : MonoBehaviour {

	GameObject Note;
	bool moveobject = false;
	private Vector3 screenPoint;
	private Vector3 offset;
	//Vector3 GRAV = new Vector3 (0.0f, -9.8f, 0.0f); 

	// Use this for initialization

	void OnMouseDown(){
		if (StopStartGame.S.dragModeOn) {
			//print ("anything??");
			//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30.0f));
		}
	}

	void OnMouseDrag(){
		if (StopStartGame.S.dragModeOn) {
			//print ("no??");
			Vector3 cursorPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30.0f);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorPoint) + offset;
			transform.position = cursorPosition;
		}
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Note") {
			Note = coll.gameObject;
			moveobject = true;
			//print ("note collide"); 
		}
	}

	void Update() {
		if (Note && moveobject) {
			//Note.GetComponent <Rigidbody>().AddForce(Vector3.up * 10.0f * -Note.gameObject.transform.position.normalized.y, ForceMode.VelocityChange);
			//Vector3 vel = Note.GetComponent <Rigidbody>().velocity;
			Note.GetComponent <Rigidbody> ().velocity +=  10.0f * Vector3.up;
			//print ("add force");
			moveobject = false;
		}
	}
}
