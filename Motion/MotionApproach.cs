using UnityEngine;
using System.Collections;

public class MotionApproach : MonoBehaviour {
    public float moveSpeed = 1.0f;
    public float stopAt = 1.5f;
    Movement3D movement;
    Vector3 playerPos;
	// Use this for initialization
	void Start () {
        movement = GetComponent<Movement3D>();
        if (!movement)
        {
            movement = gameObject.AddComponent<Movement3D>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = PlayerScript.playerObject.transform.position;
        Vector3 diff = playerPos - transform.position;
        movement.moveSpeed = moveSpeed;
        movement.Turn(Vector3.RotateTowards(transform.forward, diff, 1.0f, 1.0f));
        if (diff.magnitude > stopAt)
        {
            movement.Move(Direction.Forward);
        }
	}
}
