using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour {
	public string nextLevelScene = "";
	public string[] requiredGoals = {"CollectGoal"};
	bool allGoalsOk = false;
	CollectGoal[] goalScripts;
	void Start(){
		goalScripts = new CollectGoal[requiredGoals.Length];
		// Check if the collider is in trigger mode
		if (collider) {
			collider.isTrigger = true;
			
		} else {
			Debug.LogError("Object " + name + " doesn't have a collider. Removing GoalScript.");
			Destroy(this);
		}

		// Find the player GameObject
		GameObject player = GameObject.FindWithTag ("Player");
		// Check if the player GameObject wasn't found
		if (!player) {
			Debug.LogError ("No game object with the tag Player found!\nSet your player object's tag to Player");
		} else {
			CollectGoal[] goalComponents = player.GetComponents<CollectGoal>();
			for (int i = 0; i < requiredGoals.Length; i++) {
				foreach (CollectGoal goal in goalComponents){
					if(goal.goalName.Equals(requiredGoals[i])){
						goalScripts[i] = goal;
					}
				}
				if(!goalScripts[i]){
					Debug.LogError("CollectGoal script for goal name " + requiredGoals[i] + " was not attached to the player!" +
					               "\nAttach a CollectGoal script and set the name as " +requiredGoals[i] );
				}
			}
		}

		// Warn the user if the next level is undefined
		if (nextLevelScene.Length < 1) {
			Debug.LogWarning("Remember to set the next level name to the object " + name);
		}
	}
	
	void OnTriggerEnter(Collider c) {
		bool allGoalsCheck = true;
		foreach (CollectGoal goal in goalScripts) {
			Debug.Log (goal);
			if(!goal.IsFinished){
				allGoalsCheck = false;
			}
		}
		allGoalsOk = allGoalsCheck;
		if (allGoalsOk) {
			Application.LoadLevel (nextLevelScene);
		}
	}
}
