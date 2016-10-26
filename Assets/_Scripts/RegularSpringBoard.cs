using UnityEngine;
using System.Collections;

public class RegularSpringBoard : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	GameObject Note;
	bool moveobject = false;

	void Start(){
		//print("now I was created");
	}

	void OnMouseDown(){
		if (StopStartGame.S.dragModeOn) {
			print ("anything??");
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
			print ("note collide"); 
		}
	}

	void Update() {
		if (Note && moveobject) {
//			Note.GetComponent <Rigidbody>().AddForce(Vector3.up * -Note.gameObject.transform.position.normalized.y, ForceMode.VelocityChange);
//			print (Vector3.up * -Note.gameObject.transform.position.normalized.y);
			Note.GetComponent <Rigidbody> ().velocity +=  6.0f * Vector3.up;
			print ("add force");
			moveobject = false;
		}
	}
}
