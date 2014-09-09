using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	public string contributesTo = "CollectGoal";
	public int contributesAmount = 1;
	public bool destroyAfterPickup = true;
	void Start(){
		if (collider) {
			collider.isTrigger = true;
			
		} else {
			Debug.LogError("Object " + name + " doesn't have a collider. Removing GoalScript.");
			Destroy(this);
		}
	}
	void OnTriggerEnter(Collider c){
		c.SendMessage ("Contribute", new object[]{contributesTo, contributesAmount});
		if (destroyAfterPickup) {
			Destroy (gameObject);
		}
	}
}
