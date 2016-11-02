using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	AudioSource[] audio;
	bool clicked = false;

	void Start() {
		audio = GetComponents <AudioSource> ();
	}
	public void Clicked() {
//		for (int i = 0; i < audio.Length;) {
//			if (i > 0) {
//				print (i);
//				if (!audio [i - 1].isPlaying) {
//					audio [i].Play ();
//					print (i);
//					++i;
//				}
//			} else if(i==0){
//				print (i);
//				audio [i].Play ();
//				++i;
//			}
//		}

		audio [0].Play ();
		//print (audio.Length);
		for (int i = 1; i < audio.Length; i++) {
			print (i);
			audio [i].PlayDelayed (1+i);
		}

	}

	void Update() {
//		if (clicked) {
//			for (int i = 0; i < audio.Length;) {
//				if (i > 0) {
//					if (!audio [i - 1].isPlaying) {
//						audio [i].Play ();
//						i++;
//					}
//				} else {
//					audio [i].Play ();
//					i++;
//				}
//			}
//			clicked = false;
//		}
	}
}
