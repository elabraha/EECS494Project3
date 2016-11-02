using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BabySpawn : MonoBehaviour {
	//create spawn points
	// Use this for initialization
	public static BabySpawn B;
	public GameObject Baby;

	void Awake() {
		B = this;
	}

	public void Spawn () {
		Scene scene = SceneManager.GetActiveScene ();
//		if (scene.name == "_Scene_0") {
//			Instantiate (Baby, new Vector3(-34.5f, 13.5f, 30f), Quaternion.identity);
//			WinGameEvent.G.deadyet = 1;
//			WinGameEvent.G.babyCount = WinGameEvent.G.deadyet;
//		}
		if (scene.name == "_Scene_1") {
			Instantiate (Baby, new Vector3(-34.5f, 13.5f, 30f), Quaternion.identity);
			WinGameEvent.G.deadyet = 1;
			WinGameEvent.G.babyCount = WinGameEvent.G.deadyet;
		}
		if (scene.name == "_Scene_2") {
			Instantiate (Baby, new Vector3(-34.5f, 13.5f, 30f), Quaternion.identity);
			WinGameEvent.G.deadyet = 1;
			WinGameEvent.G.babyCount = WinGameEvent.G.deadyet;
		}
		if (scene.name == "_Scene_3") {
			Instantiate (Baby, new Vector3(-34.5f, 13.5f, 30f), Quaternion.identity);
			Instantiate (Baby, new Vector3(-34.5f, -3.5f, 30f), Quaternion.identity);
			WinGameEvent.G.deadyet = 2;
			WinGameEvent.G.babyCount = WinGameEvent.G.deadyet;
		}
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
}
