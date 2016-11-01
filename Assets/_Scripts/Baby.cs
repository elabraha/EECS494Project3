using UnityEngine;
using System.Collections;

enum Direction {LEFT, RIGHT};

public class Baby : MonoBehaviour {

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
	public bool dirchange = false;
	bool onBeam;
	Direction dir;
	bool hitnotboard = false;

	public int health;

	Vector3 fallcheck;

	bool grounded = false;

	void Start () {
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		onBeam = false;
		dir = Direction.RIGHT;
		health = 4;
	}
	void outofbounds(){
		x_boundry_max = Camera.main.transform.position.x + width / 2.0f;
		y_boundry_max = Camera.main.transform.position.y + height / 2.0f;
		x_boundry_min = Camera.main.transform.position.x - width / 2.0f;
		y_boundry_min = Camera.main.transform.position.x - height / 2.0f;
		float rad = GetComponentInChildren <CapsuleCollider> ().bounds.size.x/2.0f;
		float boundy = GetComponentInChildren <CapsuleCollider>().bounds.size.y / 2.0f;


		if (transform.position.x > x_boundry_max) {
			//			Vector3 pos = transform.position;
			//			pos.x = x_boundry_max - rad;
			//			transform.position = pos;
			//change direction maybe
			transform.position = new Vector3(x_boundry_min + rad, transform.position.y, 30.0f);
		} else if (transform.position.x < x_boundry_min) {
			//			Vector3 pos = transform.position;
			//			pos.x = x_boundry_min + rad;
			//			transform.position = pos;

			//change direcion maybe?
			print("out of bounds");
			transform.position = new Vector3(x_boundry_max - rad, transform.position.y, 30.0f);

		}

		if (transform.position.y >= y_boundry_max) {
			//			Vector3 pos = transform.position;
			//			pos.y = y_boundry_max - boundy;
			//			transform.position = pos;
		} else if (transform.position.y < y_boundry_min) {
			//			Vector3 pos = transform.position;
			//			pos.y = y_boundry_max + boundy;
			//			transform.position = pos;
			//send message to win game
			WinGameEvent.G.dead ();
			Destroy (this.gameObject);
		}
	}

	Vector3 DirToVec(Direction d) {
		if (d == Direction.LEFT) {
			return Vector3.left;
		} else {
			return Vector3.right;
		}
	}

	public void OnConveyer() {
		speed = 5.0f;
		moveObject = true;
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag != "SpringBoard") {
			//health -= 2;
			hitnotboard = true;
		}
		if(coll.gameObject.tag == "Beam") {
			//print ("you do it");
			onBeam = true;
		}
		grounded = true;

	}

	void OnCollisionExit(Collision coll) {
		if(coll.gameObject.tag == "Beam") {
			onBeam = false;
//			print ("onbeam: " + onBeam);
		}
		grounded = false;
	}


	// Update is called once per frame
	void Update () {
		//print ("onbeam: " + onBeam);

		if (grounded) {
			
			if (hitnotboard) {
				float dist = fallcheck.y - transform.position.y;
				if (dist > 1.0f) {
					health -= 2;
					hitnotboard = false;
				}
			}
			fallcheck = transform.position;
		}

		if (dirchange) {
			//print (dir); 
			int newdir = ((int)dir + 1) % 2;
			//print (dir); 
			dir = (Direction)newdir;
			//print (dir);
			dirchange = false;
		}

		if (onBeam) {
			//print ("okgo"); 
			Vector3 move = GetComponent<Rigidbody> ().velocity;
			Vector3 direction = DirToVec(dir);
			move.x =  direction.x * 100.0f * Time.deltaTime;
			GetComponent<Rigidbody> ().velocity = move;
		} else if (moveObject) {
			//print ("okgo");
			Vector3 direction = DirToVec(dir);
			speed -= speed_change * direction.x * Time.deltaTime; //change this so that it get's called from note
			Vector3 moveonbelt = GetComponent<Rigidbody> ().velocity;
			print (moveonbelt.x);
			moveonbelt.x = speed * direction.x;
			print (moveonbelt.x); 
			if ((moveonbelt.x <= 0.0f && direction.x > 0.0f) || (moveonbelt.x >= 0.0f && direction.x < 0.0f) || onBeam) {
				moveObject = false;
			}
			GetComponent<Rigidbody> ().velocity = moveonbelt;
		} else if(!onBeam && !moveObject) {
			Vector3 move = GetComponent<Rigidbody> ().velocity;
			move.x = 0.0f;
			GetComponent<Rigidbody> ().velocity = move;
		}


		outofbounds ();

	}
}
