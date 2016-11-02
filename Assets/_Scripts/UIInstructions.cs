using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInstructions : MonoBehaviour {

	public Text toggle;
	bool ifpressed = true;

	public void pressed() {
		ifpressed = !ifpressed;
	}
	
	// Update is called once per frame
	void Update () {
		if (ifpressed) {
			toggle.enabled = true;
		} else {
			toggle.enabled = false;
		}
	}
}
