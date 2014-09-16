using UnityEngine;
using System.Collections;

public class GenericGameOverGUI : MonoBehaviour {
	public string ContinueLevel = "Level1";
	public string MainMenuScene = "MainMenu";
	Rect areaRect;
	void Start(){
		areaRect = new Rect ();
	}
	void OnGUI(){
		int w = Screen.width;
		int h = Screen.height;
		areaRect.x = w * 0.25f;
		areaRect.y = h * 0.25f;
		areaRect.width = w * 0.5f;
		areaRect.height = h * 0.5f;
		
		GUILayout.BeginArea (areaRect);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Your score: " + PlayerScript.score);
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		if (GUILayout.Button ("Continue", GUILayout.ExpandHeight (true))) {
			Application.LoadLevel(ContinueLevel);
		}
		if (GUILayout.Button ("Quit to main menu", GUILayout.ExpandHeight (true))) {
			Application.LoadLevel(MainMenuScene);
		}
		GUILayout.EndArea ();
	}
}
