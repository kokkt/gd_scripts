using UnityEngine;
using System.Collections;
using System;

public class WaypointMotion : MonoBehaviour {
	public enum ReturnBehaviour {GoToBeginning, ReturnTheSameRoute}
	public bool stopAtLastWP = false;
	public bool loop = true;
	public ReturnBehaviour atGoal = ReturnBehaviour.ReturnTheSameRoute;
	public Transform[] waypoints = new Transform[1];
	public float moveSpeed = 1.0f;
	public bool smoothTurns = false;
	public float turnSharpness = 1.0f;
	public float proximityReq = 0.5f;
	public bool moving = true;
	int waypointTarget = 0;
	bool returning = false;
	Vector3 direction = new Vector3();
	Vector3 lastDir;
	float distance = 0.0f;
	float turnTime = 0.0f;
	void Start () {
		Transform[] startPos = new Transform[waypoints.Length+1];
		startPos [0] = (GameObject.Instantiate(new GameObject(), transform.position, Quaternion.identity) as GameObject).transform;
		startPos [0].name = "Waypoint Start";
		Array.Copy (waypoints, 0, startPos, 1, waypoints.Length);
		waypoints = startPos;
	}

	void Update () {
		if (moving) {
			direction = waypoints [waypointTarget].position - transform.position;
			distance = direction.magnitude;
			if (distance > proximityReq) {
				Vector3 targetDir = direction;
				if(smoothTurns){
					turnTime += Time.deltaTime;
					targetDir = Vector3.Lerp(lastDir, direction, Time.deltaTime*turnSharpness*turnTime); // Division to gain more accuracy
				}
				transform.Translate (targetDir.normalized * (moveSpeed * Time.deltaTime));
				lastDir = targetDir;
			} else {
				AtWaypoint ();
			}
		}
	}
	void AtWaypoint(){
		if (!returning) {
			if(waypointTarget + 1 < waypoints.Length){ //There are waypoints left
				waypointTarget += 1;
			} else {
				AtGoal();
			}
		} else {
			if(waypointTarget > 0){
				waypointTarget -= 1;
			} else {
				AtGoal();
			}
		}
		turnTime = 0.0f;
		//Debug.Log ("Moving to " + waypointTarget);	
	}
	void AtGoal(){
		//Debug.Log ("At goal "+waypointTarget+":" + atGoal + ", returning: " + returning);
		if (!loop && waypointTarget == 0 && returning) {
			moving = false;
		}
		if (stopAtLastWP && waypointTarget == waypoints.Length - 1) {
			moving = false;
		}
		switch (atGoal) {
		case ReturnBehaviour.GoToBeginning:
			if(waypointTarget != 0){
				waypointTarget = 0;
			}
			break;
		case ReturnBehaviour.ReturnTheSameRoute:
			if(!returning){
				waypointTarget--;
			} else {
				waypointTarget++;
			}
			break;
		}
		
		returning = !returning;
	}
}
