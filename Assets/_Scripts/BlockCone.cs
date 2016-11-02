using UnityEngine;
using System.Collections;

public class BlockCone : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;


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
		
}
