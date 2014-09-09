using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel("mainscene");
		}
	
	}

	void OnGUI(){
		GUILayout.Label ("Press any key to continue");
	}
}
