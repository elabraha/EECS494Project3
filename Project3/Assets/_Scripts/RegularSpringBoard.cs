using UnityEngine;
using System.Collections;

public class RegularSpringBoard : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	void Start(){
		print("now I was created");
	}

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
}
