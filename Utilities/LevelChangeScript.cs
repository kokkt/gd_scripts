using UnityEngine;
using System.Collections;

public class LevelChangeScript : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		Application.LoadLevel ("WinScene");
	}
}
