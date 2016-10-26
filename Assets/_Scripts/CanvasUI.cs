using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasUI : MonoBehaviour {
	public Text box;

	// Use this for initialization
	void Start () {
		box.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (WinGameEvent.G.ifdead) {
			box.enabled = true;
			box.text = "enter to restart. esc to quit";
		}
		if (WinGameEvent.G.wrong) {
			box.enabled = true;
			box.text = "wrong";
		}
		if(WinGameEvent.G.win) {
			box.enabled = true;
			box.text = "WIN!! enter to restart. esc to quit";
		}

		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			SceneManager.LoadScene ("_Scene_0");
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SceneManager.LoadScene ("_Scene_1");
		}
	}
}
