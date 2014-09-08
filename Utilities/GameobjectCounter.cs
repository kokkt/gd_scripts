using UnityEngine;
using System.Collections;

public class GameobjectCounter : MonoBehaviour {
	public static int gameObjects = 0;

	void OnGUI(){
		GUILayout.Label ("Game objects: " + gameObjects);
	}
}
