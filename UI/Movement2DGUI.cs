using UnityEngine;
using System.Collections;

public class Movement2DGUI : MonoBehaviour {
	public Rect controlRect = new Rect (128, 128, Screen.width, 256);
	Movement2D control;
	// Use this for initialization
	void Start () {
		control = GetComponent<Movement2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.BeginArea (controlRect);
		if (GUILayout.RepeatButton ("Left", GUILayout.ExpandHeight (true))) {
			control.Move(true);
		}
		if (GUILayout.RepeatButton ("Jump", GUILayout.ExpandHeight (true))) {
			control.Jump(control.jumpForce);
		}
		if (GUILayout.RepeatButton ("Right", GUILayout.ExpandHeight (true))) {
			control.Move(false);
		}
		GUILayout.EndArea ();
	}
}
