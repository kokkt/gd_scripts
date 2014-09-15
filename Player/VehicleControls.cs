using UnityEngine;
using System.Collections;

public class VehicleControls : MonoBehaviour {
	public float acceleration = 0.1f;
	public float maxSpeed = 3.0f;
	public float turnSpeed = 1.0f;

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
		if (Input.GetAxis ("Horizontal") != 0) {
			turn.y = Input.GetAxis("Horizontal")*turnSpeed;
			transform.Rotate(turn);
		}
		float up = Input.GetAxis ("Vertical");
		if (up != 0) {

			if(up > 0 && currentSpeed < maxSpeed){
				currentSpeed += acceleration*Time.deltaTime;
			} else if (up < 0 && currentSpeed > 0){
				currentSpeed -= acceleration * Time.deltaTime;
			}

		}
		direction = transform.forward * currentSpeed;
		if (currentSpeed > 0) {
			cc.Move (direction);
		}
	}
}
