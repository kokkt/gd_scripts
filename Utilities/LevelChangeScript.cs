using UnityEngine;
using System.Collections;

public class LevelChangeScript : MonoBehaviour {
	string nextLevel = "";
	void OnTriggerEnter(Collider c){
		Application.LoadLevel (nextLevel);
	}
}
