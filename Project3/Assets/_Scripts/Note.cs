using UnityEngine;
using System.Collections;
using System;

public class Note : MonoBehaviour {

	// Use this for initialization
	float x_boundry_min = 0.0f;
	float x_boundry_max = 0.0f;
	float y_boundry_min = 0.0f;
	float y_boundry_max = 0.0f;
	float height = 0.0f;
	float width = 0.0f;
	//public bool onbelt = false;
	float speed = 0.0f;
	bool moveObject = false;
	float speed_change = 0.5f;

	void Start () {
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
	}
	void outofbounds(){
		x_boundry_max = Camera.main.transform.position.x + width / 2.0f;
		y_boundry_max = Camera.main.transform.position.y + height / 2.0f;
		x_boundry_min = Camera.main.transform.position.x - width / 2.0f;
		y_boundry_min = Camera.main.transform.position.x - height / 2.0f;
		float rad = GetComponent <CapsuleCollider> ().bounds.size.x / 2.0f;
		float boundy = GetComponent <CapsuleCollider>().bounds.size.y / 2.0f;


		if (transform.position.x >= x_boundry_max) {
//			Vector3 pos = transform.position;
//			pos.x = x_boundry_max - rad;
//			transform.position = pos;
		} else if (transform.position.x < x_boundry_min) {
//			Vector3 pos = transform.position;
//			pos.x = x_boundry_min + rad;
//			transform.position = pos;
		}

		if (transform.position.y >= y_boundry_max) {
//			Vector3 pos = transform.position;
//			pos.y = y_boundry_max - boundy;
//			transform.position = pos;
		} else if (transform.position.y < y_boundry_min) {
//			Vector3 pos = transform.position;
//			pos.y = y_boundry_max + boundy;
//			transform.position = pos;
			Destroy (this.gameObject);
		}
	}

	public void OnConveyer() {
			speed = 5.0f;
			moveObject = true;
	}

		
	// Update is called once per frame
	void Update () {
		if (moveObject) {
			speed -= speed_change * Time.deltaTime; //change this so that it get's called from note
			Vector3 moveonbelt = GetComponent<Rigidbody> ().velocity;
			moveonbelt.x = speed;
			if (moveonbelt.x <= 0.0f) {
				moveObject = false;
			}
			GetComponent<Rigidbody> ().velocity = moveonbelt;
		}

		outofbounds ();

	}
}
