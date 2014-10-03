using UnityEngine;
using System.Collections;

public class GenericVictoryScreenGUI : MonoBehaviour {
	public string MainMenuScene = "MainMenu";
	public string MainMenuButtonText = "Back to Main Menu";
	public string ScoreName = "points";
	Rect areaRect;
    Score score;
	void Start(){
        areaRect = new Rect();
        score = PlayerScript.GetAttribute(typeof(Score)) as Score;
        if (!score)
        {
            Debug.LogWarning("Player doesn't have a Score component!");
        }
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
		GUILayout.Label ("You win!\nYour "+ScoreName+": " + score.score);
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		if (GUILayout.Button (MainMenuButtonText, GUILayout.ExpandHeight (true))) {
			Application.LoadLevel(MainMenuScene);
		}
		GUILayout.EndArea ();
	}
}
