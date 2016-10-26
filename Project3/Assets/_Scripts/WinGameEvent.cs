using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinGameEvent : MonoBehaviour {

	int triggerplay = 0;
	public List<int> played = new List<int>();
	int[] order;

	public static WinGameEvent G;

	void Awake() {
		G = this;
	}

	// Use this for initialization
	void Start () {
		order = new int[4];
		order[0] = 1;
		order[1] = 2;
		order[2] = 3;
		order[3] = 4;
	}

	public void uptrigger() {
		triggerplay++;
	}
	
	// Update is called once per frame
	void Update () {
		bool played_right = true;
		//if (played.Count == order.Length) {
		for (int i = 0; i < played.Count; ++i) {
			if (order [i] != played [i]) {
				played_right = false;
				print ("wrong at " + i); 
				break;
			}
		}
		//}
		//if (!played_right) print ("wrong");
	}
}
