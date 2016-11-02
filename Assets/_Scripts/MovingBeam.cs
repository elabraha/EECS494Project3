using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.EventSystems;
using System.Collections.Specialized;

public class MovingBeam: MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	bool moveobject = false;
	private Vector3 start;
	public bool isupdown = false;
	public bool ispos = true;
	bool collided = false;
	float speed = 2.0f;
	float timer = 0.0f;
	float velocitybaby = 0.0f;
	bool hasbaby = false;

	void Start(){
		print ("was dropped");
		start = transform.position;
	}

	void OnCollisionEnter(Collision coll) {
		//print ("collide " + this.gameObject.name);
		if (coll.gameObject.tag == "Baby") {
			//velocitybaby = coll.gameObject.GetComponent <Rigidbody>().velocity();
			hasbaby = true;
		} else {
			timer = 3.0f;
			collided = true;
		}
	}
		

	void OnCollisionExit(Collision coll) {
		hasbaby = false;
	}
		

//	void OnMouseDown(){
//		if (StopStartGame.S.dragModeOn) {
//			//print ("anything??");
//			//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
//			offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30.0f));
//		}
//	}
//
//	void OnMouseDrag(){
//		if (StopStartGame.S.dragModeOn) {
//			//print ("no??");
//			Vector3 cursorPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30.0f);
//			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorPoint) + offset;
//			transform.position = cursorPosition;
//		}
//	}
//
	bool bounds() {
		bool direction_change = false;
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		float x_boundry_max, y_boundry_max, x_boundry_min, y_boundry_min;
		Collider thisone = GetComponent <Collider> ();
		x_boundry_max = Camera.main.transform.position.x + width / 2.0f;
		y_boundry_max = Camera.main.transform.position.y + height / 2.0f;
		x_boundry_min = Camera.main.transform.position.x - width / 2.0f;
		y_boundry_min = Camera.main.transform.position.x - height / 2.0f;
		if(isupdown && (y_boundry_max < (transform.position.y + thisone.bounds.size.y/2.0f))) {
			direction_change = true;
		} else if (isupdown && (y_boundry_min > (transform.position.y - thisone.bounds.size.y/2.0f))) {
			direction_change = true;
		}

		if(!isupdown && (x_boundry_max < (transform.position.x + thisone.bounds.size.x/2.0f))) {
			//print ("what are you doing?");
			direction_change = true;
		} else if(!isupdown && (x_boundry_min > (transform.position.x - thisone.bounds.size.x/2.0f))) {
			//print ("what are you doing?");
			direction_change = true;
		}
		return direction_change;
	}

	void Update() {
//		if (hasbaby) {
//			GetComponentInChildren <Baby>().gameObject.GetComponent <Rigidbody>().velocity;
//		}
		if (bounds() || collided) {
			timer -= Time.deltaTime;
			if (timer <= 0.0f) {
				if (ispos && !isupdown) {
					transform.Translate (Vector3.left * Time.deltaTime * speed);
					ispos = false;
				} else if (!isupdown && !ispos) {
					transform.Translate (Vector3.right * Time.deltaTime * speed);
					ispos = true;
				} else if (ispos && isupdown) {
					transform.Translate (Vector3.down * Time.deltaTime * speed);
					ispos = false;
				} else if (isupdown && !ispos) {
					transform.Translate (Vector3.up * Time.deltaTime * speed);
					ispos = true;
				}
				collided = false;
			}
		} else {
			if (ispos && !isupdown) {
				transform.Translate (Vector3.right * Time.deltaTime * speed);
			} else if (!ispos && !isupdown){
				transform.Translate (Vector3.left * Time.deltaTime * speed);
			} else if(ispos && isupdown) {
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			} else if(!ispos && isupdown) {
				transform.Translate (Vector3.down * Time.deltaTime * speed);
			}
		}
	}



}
