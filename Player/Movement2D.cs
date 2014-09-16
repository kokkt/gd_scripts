using UnityEngine;
using System.Collections;

public class Movement2D : MonoBehaviour {
	public bool runConstantly = false;
	public float movementSpeed = 5.0f;
	public Vector2 jumpForce = new Vector2(0.5f, 10.0f);
	public float gravity = 8.0f;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode jumpKey = KeyCode.Space;
	CharacterController cc;
	bool jumpAvailable = true;
	Vector2 moveDir = new Vector2(0,0);
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		if (!cc) {
			cc = gameObject.AddComponent<CharacterController> ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
		moveDir.x = 0;
		if (runConstantly) {
			Move (false);
		} else {
			if (Input.GetKey (leftKey)) {
				Move (true);
			}
			if (Input.GetKey (rightKey)) {
				Move (false);
			}
		}
		if (Input.GetKeyDown (jumpKey) || Input.GetMouseButtonDown(0)) {
			Jump (jumpForce);
		}
		if (cc.isGrounded) {
			jumpAvailable = true;
		} else {
			moveDir.y -= gravity/10 * Time.deltaTime;
		}
		cc.Move (moveDir);
	
	}
	public void Move(bool left){
		moveDir.x = movementSpeed * Time.deltaTime;
		if (left) {
			moveDir.x *= -1;
		}
	}
	public void Jump(Vector2 force){
		if (jumpAvailable) {
			moveDir.y = force.y/30;
			moveDir.x = force.x/30;
			jumpAvailable = false;
		}
	}
}
