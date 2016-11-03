using UnityEngine;
using System.Collections;

public class RegularSpringBoard : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	bool moveobject = false;
	bool individualdragtoggle;
	GameObject Baby;

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
		print ("I have collided");
		if (coll.gameObject.tag == "Baby") {
			Baby = coll.gameObject;
			moveobject = true;
			individualdragtoggle = false;
		}
	}

	void Update() {
		if (Baby && moveobject) {
//			Note.GetComponent <Rigidbody>().AddForce(Vector3.up * -Note.gameObject.transform.position.normalized.y, ForceMode.VelocityChange);
//			print (Vector3.up * -Note.gameObject.transform.position.normalized.y);
			Baby.GetComponent <Rigidbody> ().velocity +=  6.0f * Vector3.up;
			print ("add force");
			moveobject = false;
		}
	}
}
