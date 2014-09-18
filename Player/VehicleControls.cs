using UnityEngine;
using System.Collections;

public class VehicleControls : MonoBehaviour {
	public KeyCode accelerationKey = KeyCode.W;
	public KeyCode brakeKey = KeyCode.S;
	public KeyCode turnLeftKey = KeyCode.A;
	public KeyCode turnRightKey = KeyCode.D;

	public float acceleration = 0.5f;
	public float deceleration = 0.1f;
	public float brake = 0.9f;
	public float maxSpeed = 3.0f;
	public float turnSpeed = 1.0f;
	public float gravity = 8.0f;

	public float currentSpeed = 0.0f;
	Vector3 direction = new Vector3();
	Vector3 turn = new Vector3 ();
	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		if (!cc) {
			cc = gameObject.AddComponent<CharacterController>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		turn.y = 0;
		if (Input.GetKey (turnLeftKey)) {
			turn.y = -turnSpeed;
		} else if (Input.GetKey (turnRightKey)) {
			turn.y = turnSpeed;
		}
		transform.Rotate(turn);
		if (Input.GetKey (accelerationKey) && currentSpeed < maxSpeed) {
						currentSpeed += acceleration * Time.deltaTime;
				} else if (Input.GetKey (brakeKey) && currentSpeed > 0) {
						currentSpeed -= acceleration * Time.deltaTime;
				} else if (currentSpeed > 0) {
						currentSpeed -= deceleration * Time.deltaTime;
				} else {
						currentSpeed = 0;
				}
		direction.x = transform.forward.x * currentSpeed;
		direction.z = transform.forward.z * currentSpeed;
		if (!cc.isGrounded) {
			direction.y -= gravity / 10 * Time.deltaTime;
		} else {
			direction.y = 0;
		}
		cc.Move (direction);
	}
}
