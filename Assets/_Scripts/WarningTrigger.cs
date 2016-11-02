using UnityEngine;
using System.Collections;

public class WarningTrigger : MonoBehaviour {

	// Use this for initialization

	SpriteRenderer sprite;
	SpriteRenderer sprite1;
	void Start () {
		sprite =transform.parent.GetComponentsInChildren <SpriteRenderer> ()[1];
		sprite1 = transform.parent.GetComponentsInChildren <SpriteRenderer> ()[0];
		Color color = sprite.color;
		color.a = 0.0f;
		sprite.color = color;
		sprite1.color = color;
	}
	
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Baby") {
			Color color = sprite.color;
			color.a = 255f;
			sprite.color = color;
			sprite1.color = color;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Baby") {
			Color color = sprite.color;
			color.a = 0.0f;
			sprite.color = color;
			sprite1.color = color;
		}
	}
}
