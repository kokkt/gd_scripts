using UnityEngine;
using System.Collections;

public class HelperTextScript : MonoBehaviour {
	[Multiline]
	public string helpText = "Help text here";
	public float textHeight = 1.5f;
	public bool facePlayer = true;
	public float turnSpeed = 0.5f;
	TextMesh textMesh;
	void Awake () {
		textMesh = GetComponentInChildren<TextMesh> ();
		textMesh.text = helpText;
		textMesh.alignment = TextAlignment.Center;
		textMesh.anchor = TextAnchor.LowerCenter;
		Vector2 textPos = new Vector2(0, textHeight);
		textMesh.transform.localPosition = textPos;

	
	}

	void Update () {
		if (facePlayer) {
			Quaternion dir = GameObject.FindWithTag ("MainCamera").transform.rotation;
			dir.x = 0;
			dir.z = 0;
			transform.rotation = Quaternion.Lerp (transform.rotation, dir, turnSpeed);
		}
	
	}
}
