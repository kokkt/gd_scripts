using UnityEngine;
using System.Collections;

public class GenericMainMenuGUI : MonoBehaviour {
	public string NextLevel = "Level1";
	Rect areaRect;
	void Start(){
		areaRect = new Rect ();
	}
	void OnGUI(){
		int w = Screen.width;
		int h = Screen.height;
		areaRect.x = w * 0.25f;
		areaRect.y = h * 0.5f;
		areaRect.width = w * 0.5f;
		areaRect.height = h * 0.4f;

		GUILayout.BeginArea (areaRect);
		if (GUILayout.Button ("Start", GUILayout.ExpandHeight (true))) {
			Application.LoadLevel(NextLevel);
		}
		if (GUILayout.Button ("Quit", GUILayout.ExpandHeight (true))) {
			Application.Quit();
		}
		GUILayout.EndArea ();
	}
}
