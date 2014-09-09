using UnityEngine;
using System.Collections;

public class FreezeRotation : MonoBehaviour {
	Quaternion rotation_freeze;
	// Use this for initialization
	void Start () {
		rotation_freeze = transform.rotation;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = rotation_freeze;
	}
}
