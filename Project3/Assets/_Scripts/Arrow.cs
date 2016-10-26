using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	float starttime = 0.0f;
	Vector3 finishpos;
	GameObject objectToMove;
	bool moveObject = false;
	public float timetodest = 1.0f;
	Vector3 startpos;

	// Use this for initialization
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Note") {
			objectToMove = coll.gameObject;
			starttime = Time.time;
			moveObject = true;
			startpos = coll.gameObject.transform.position;
			finishpos.y = coll.gameObject.transform.position.y + 10.0f;
		}
	}
	// Update is called once per frame
	void Update () {
		if (objectToMove && moveObject) {
			float timeSinceStarted = Time.time - starttime;
			float percentageComplete = timeSinceStarted / timetodest;
			objectToMove.transform.position = Vector3.Lerp (startpos, finishpos, percentageComplete);
			if(percentageComplete >= 1.0f)
			{
				moveObject = false;
			}
		}
	}
}
