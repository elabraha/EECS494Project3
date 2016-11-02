using UnityEngine;
using System.Collections;

public class SuperSpringboard : MonoBehaviour {

	GameObject Baby;
	bool moveobject = false;
	private Vector3 screenPoint;
	private Vector3 offset;
	bool individualdragtoggle;

	void Start(){
		//print("now I was created");
		individualdragtoggle = true;
	}

	void OnMouseDown(){
		if (StopStartGame.S.dragModeOn || individualdragtoggle == true) {
			print ("anything??");
			//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30.0f));
		}
	}

	void OnMouseDrag(){
		if (StopStartGame.S.dragModeOn || individualdragtoggle == true) {
			//print ("no??");
			Vector3 cursorPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30.0f);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorPoint) + offset;
			transform.position = cursorPosition;
		}
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Baby") {
			Baby = coll.gameObject;
			moveobject = true;
			individualdragtoggle = false;
		}
	}
	void OnCollisionExit(Collision coll) {
		if (coll.gameObject.tag == "Baby") {
			individualdragtoggle = false;
		}
	}

	void Update() {
		if (Baby && moveobject) {
			//Note.GetComponent <Rigidbody>().AddForce(Vector3.up * 10.0f * -Note.gameObject.transform.position.normalized.y, ForceMode.VelocityChange);
			//Vector3 vel = Note.GetComponent <Rigidbody>().velocity;
			Baby.GetComponent <Rigidbody> ().velocity +=  10.0f * Vector3.up;
			//print ("add force");
			moveobject = false;
		}
	}
}
