using UnityEngine;
using System.Collections;

public class Movement3D : MonoBehaviour {
    CharacterController cc;
    KeyCode forwardKey = KeyCode.W;
    KeyCode backwardKey = KeyCode.S;
    KeyCode turnLeft = KeyCode.A;
    KeyCode turnRight = KeyCode.D;
    KeyCode jump = KeyCode.Space;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        if (!cc)
        {
            gameObject.AddComponent<CharacterController>();
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
