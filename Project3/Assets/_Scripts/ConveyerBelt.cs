using UnityEngine;
using System.Collections;
using System;

public class ConveyerBelt : MonoBehaviour {

	//float starttime = 0.0f;
	//Vector3 finishpos;
	//GameObject objectToMove;
	bool moveObject = false;
	public float timetodest = 1.0f;
	//Vector3 startpos;
	float speed = 0.0f;
	float speed_change = 0.5f;


	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown(){
		print ("anything??");
		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30.0f));
	}

	void OnMouseDrag(){
		print ("no??");
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30.0f);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}



	void Start(){
//		BoxCollider b = this.GetComponent <Collider> () as BoxCollider;
//		Vector3 collidersize = b.size;
//		Vector3 pos = transform.position;
//		pos.x = pos.x + collidersize.x / 2.0f + 1.4f;
//		pos.y = pos.y + collidersize.y / 2.0f;
//		finishpos = pos;
		//print("now I was created");
	}

	// Use this for initialization
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Note") {
			//objectToMove = coll.gameObject;
			//starttime = Time.time;
			//startpos = coll.gameObject.transform.position;
			//finishpos.y = coll.gameObject.transform.position.y;

			//moveObject = true;
			//speed = 5.0f;

			coll.gameObject.GetComponent <Note>().OnConveyer ();
		}
	}


	// Update is called once per frame
	void Update () {
		if (/*objectToMove &&*/ moveObject) {
//			float timeSinceStarted = Time.time - starttime;
//			float percentageComplete = timeSinceStarted / timetodest;
//			objectToMove.transform.position = Vector3.Lerp (startpos, finishpos, percentageComplete);
//			if(percentageComplete >= 1.0f)
//			{
//				moveObject = false;
//			}
//			speed -= speed_change * Time.deltaTime; //change this so that it get's called from note
//			Vector3 moveonbelt = objectToMove.GetComponent<Rigidbody> ().velocity;
//			moveonbelt.x = speed;
//			if (moveonbelt.x <= 0.0f) {
//				moveObject = false;
//			}
//			objectToMove.GetComponent<Rigidbody> ().velocity = moveonbelt;

		}
	}
}
