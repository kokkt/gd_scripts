using UnityEngine;
using System.Collections;

public class CollectGoal : MonoBehaviour {
	public int targetAmount = 10;
	public string goalName = "CollectGoal";
	public bool showProgressUI = true;
	public Vector2 progressUIPosition = new Vector2 (8, 8);
	public Vector2 progressUISize = new Vector2 (128, 32);
	public bool IsFinished { get {return finished;} }
	bool finished = false;
	Rect progressRect;
	int progress = 0;
	//public Reward reward;

	void Start(){
		progressRect = new Rect (progressUIPosition.x, progressUIPosition.y, progressUISize.x, progressUISize.y);
	}
	public void Contribute(object[] par) {
		string targetGoal = par [0] as string;
		if (targetGoal.Equals (goalName) && !finished) {
			int amount = (int)par [1];
			progress += amount;
			if(progress >= targetAmount){
				FinishGoal();
			}
		}
		Debug.Log (progress);
	}
	void FinishGoal() {
		finished = true;
		SendMessageUpwards ("GoalFinished", goalName);
	}
	void OnGUI(){
		if (showProgressUI) {
			if(!finished){
				GUI.Label(progressRect, goalName + ": " + progress + "/" + targetAmount);
			} else {
				GUI.Label(progressRect, goalName + " finished!");
			}
		}
	}
}
