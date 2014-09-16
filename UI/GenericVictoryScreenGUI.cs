using UnityEngine;
using System.Collections;

public class GenericVictoryScreenGUI : MonoBehaviour {
	public string MainMenuScene = "MainMenu";
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
		areaRect.height = h * 0.25f;
		
		GUILayout.BeginArea (areaRect);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("You win!\nYour score: " + PlayerScript.score);
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		if (GUILayout.Button ("Back to main menu", GUILayout.ExpandHeight (true))) {
			Application.LoadLevel(MainMenuScene);
		}
		GUILayout.EndArea ();
	}
}
