using UnityEngine;
using System.Collections;

public class StopStartGame : MonoBehaviour {

	GameObject[] gameObjects;
	public GameObject Notes;
	bool uimode = true;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas.enabled = true;
	}

	void Spawn()
	{
		print ("why not going");
		InvokeRepeating("SpawnObject", 2, 10);
	}

	void DestroyAllObjects()
	{
		gameObjects = GameObject.FindGameObjectsWithTag ("Note");

		for(var i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
		}
	}

	void SpawnObject() {
		Vector3 newnote = new Vector3 (-30f, 19f, 30f);
		Instantiate (Notes, newnote, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (uimode) {
				CancelInvoke ();
				DestroyAllObjects ();
				canvas.enabled = true;
			} else {
				Spawn ();
				canvas.enabled = false;
			}
			uimode = !uimode;
			print (uimode); 
		}
	}
}
