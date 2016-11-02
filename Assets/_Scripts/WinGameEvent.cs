using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Security.Principal;

public class WinGameEvent : MonoBehaviour {

	int triggerplay = 0;
	public List<int> played = new List<int>();
	public int[] order;
	public int deadyet;
	public bool wrong;
	public bool win;
	float timeWrong = 30.0f;
	public static WinGameEvent G;
	public int babyCount = 0;
	public GameObject cribPrefab;
	public int babySleep = 0;
	AudioSource source;

	void Awake() {
		G = this;
		source = GetComponent <AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		//deadyet is number of babies on each level
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "_Scene_1") {
			order = new int[2];
			order [0] = 1;
			order [1] = 2;
		}
		if (scene.name == "_Scene_2") {
			order = new int[2];
			order [0] = 1;
			order [1] = 2;
		}
		wrong = false;
		win = false;
	}

	public void uptrigger() {
		triggerplay++;
	}

	public void dead() {
		deadyet -= 1;
		//print ("I ded");
	}
	
	// Update is called once per frame
	void Update () {
		if (deadyet <= 0) {
			//menu
			if (Input.GetKeyDown("return")) {
				print ("reload??");
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}
		} else {
			bool played_right = true;
			//if (played.Count == order.Length) {
			for (int i = 0; i < played.Count; ++i) {
//				print (i);
//				print (order [i]);
//				print (played [i]);
				if (order [i] != played [i]) {
					played_right = false;
					print ("wrong at " + i); 
					break;
				}
			}
			//}
			if (!played_right) {
				wrong = true;
			} else if(played.Count == order.Length && played_right || Input.GetKeyDown (KeyCode.Alpha1))  {
				GameObject [] notes = GameObject.FindGameObjectsWithTag ("Note");
		
				for(var i = 0 ; i < notes.Length ; i ++)
				{
					Destroy(notes[i]);
				}
				Scene scene = SceneManager.GetActiveScene();
				if (scene.name == "_Scene_1")
					Instantiate (cribPrefab, new Vector3(-32f, -6f, 30f), Quaternion.identity);
				else if(scene.name == "_Scene_2")
					Instantiate (cribPrefab, new Vector3(30.15f, -6f, 30f), Quaternion.identity);
				else 
					Instantiate (cribPrefab, new Vector3(0f, -4f, 30f), Quaternion.identity);
			}
			if(wrong) {
				timeWrong -= Time.deltaTime;
				if (timeWrong < 0) {
					wrong = false;
					timeWrong = 30.0f;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			babySleep = babyCount;
		}
		if (babySleep == babyCount) {
			source.Play ();
			win = true;
			babyCount = 0;
		}

		if (win) {
			//menu
			if (Input.GetKeyDown("return")) { // change to clicking to load the next level
				Scene scene = SceneManager.GetActiveScene();
				//Scene newscene = scene;
				if (scene.name == "_Scene_1") {
					SceneManager.LoadScene("_Scene_2");
				} else {
					SceneManager.LoadScene("_Scene_2");
				}
			}
		}

		if(Input.GetKeyDown("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
			Application.Quit(); // Quits the game
		}
	}
}
