﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StopStartGame : MonoBehaviour {

	GameObject[] gameObjects;
	public GameObject Notes;
	bool uimode = true;
	public bool dragModeOn = true;
	public Canvas canvas;
	public static StopStartGame S;
	//public Vector3 pos;
	// Use this for initialization

	void Awake() {
		S = this;
	}
	void Start () {
		canvas.enabled = true;
		uimode = true;
		dragModeOn = true;
	}

	void Spawn()
	{
		print ("why not going");
		//InvokeRepeating("SpawnObject", 2, 10);
		Invoke("SpawnObject", 2.0f);
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
		Vector3 newnote = new Vector3(-32f, 18f, 30f);;
		Instantiate (Notes, newnote, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if (WinGameEvent.G.ifdead == true || WinGameEvent.G.win == true) {
			CancelInvoke ();
			DestroyAllObjects ();
			canvas.enabled = true;
			dragModeOn = false;
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				uimode = !uimode;
				if (uimode) {
					CancelInvoke ();
					DestroyAllObjects ();
					canvas.enabled = true;
					print ("what is happening"); 
				} else {
					Spawn ();
					canvas.enabled = false;
					print ("should be disabled now"); 
				}
				dragModeOn = uimode;
				print (uimode); 
			}
		}


	}
}
