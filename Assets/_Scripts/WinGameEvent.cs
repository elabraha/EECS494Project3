using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Security.Principal;

public class WinGameEvent : MonoBehaviour {

	int triggerplay = 0;
	public List<int> played = new List<int>();
	int[] order;
//	public bool ifdead;
	public bool wrong;
	public bool win;

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
//		ifdead = false;
		wrong = false;
		win = false;
	}

	public void uptrigger() {
		triggerplay++;
	}

//	public void dead() {
//		ifdead = true;
//	}
	
	// Update is called once per frame
	void Update () {
//		if (ifdead) {
//			//menu
//			print ("dead"); 
//			if (Input.GetKeyDown("return")) {
//				Scene scene = SceneManager.GetActiveScene();
//				SceneManager.LoadScene(scene.name);
//			}
//		} else {
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
			if (!played_right) {
				wrong = true;
			} else if(played.Count == order.Length && played_right)  {
				win = true;
			}
//		}

		if (win) {
			if (Input.GetKeyDown("return")) {
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}
		}

		if(Input.GetKeyDown("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
			Application.Quit(); // Quits the game
		}
	}
}
