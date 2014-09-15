using UnityEngine;
using System.Collections;

public class LevelChangeScript : MonoBehaviour {
	public string nextLevel = "";
	void OnTriggerEnter(Collider c){
		Application.LoadLevel (nextLevel);
	}
}
